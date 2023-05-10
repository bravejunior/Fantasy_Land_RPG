using Fantasy_Land_Web_Api.Context;
using Fantasy_Land_Web_Api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Configurations;
using Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Fantasy_Land_Web_Api.Token_Management
{
    public class TokenService : ITokenService
    {
        private readonly FantasyLandDbContext _dbContext;
        private readonly JwtConfig _jwtConfig;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;



        public TokenService(FantasyLandDbContext dbContext, JwtConfig jwtConfig, UserManager<User> userManager, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._jwtConfig = jwtConfig;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResult> RefreshAccessTokenAsync(string refreshToken)
        {
            var rToken = await _dbContext.RefreshTokens.FirstOrDefaultAsync(t => t.Token == refreshToken);

            if (rToken == null)
            {
                throw new ArgumentException("Invalid refresh token.");
            }

            if (rToken.Expires <= DateTime.UtcNow)
            {
                throw new ArgumentException("Refresh token expired.");
            }

            var user = await _userManager.FindByIdAsync(rToken.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var authResult = GenerateAccessToken(user);

            return authResult;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<RefreshToken> UpdateRefreshTokenAsync(string userid)
        {
            var refreshToken = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(t => t.UserId == userid);

            if (refreshToken != null && refreshToken.Expires > DateTime.Now)
            {
                return refreshToken;
            }

            if (refreshToken != null)
            {
                refreshToken.Token = GenerateRefreshToken();
                refreshToken.Expires = DateTime.Now.AddMinutes(_jwtConfig.RefreshTokenExpiration);
                _dbContext.RefreshTokens.Update(refreshToken);
                await _dbContext.SaveChangesAsync();
                return refreshToken;
            }

            return refreshToken;
        }

        public AuthResult GenerateAccessToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secret = Environment.GetEnvironmentVariable("FANTASY_LAND_SECRET");
            var key = Encoding.UTF8.GetBytes(secret);


            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var audience = _configuration.GetValue<string>("JwtSettings:Audience");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    // adding claims to access token
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Aud, audience),
                    new Claim(JwtRegisteredClaimNames.Iss, issuer),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return new AuthResult { AccessToken = jwtToken, Username = user.UserName };
        }

        public async Task<RefreshToken> GetRefreshTokenAsync(string userId)
        {
            bool exists = _dbContext.RefreshTokens.Any(x => x.UserId == userId);

            if (exists)
            {
                var refreshToken = await _dbContext.RefreshTokens
                 .FirstOrDefaultAsync(t => t.UserId == userId);

                if (refreshToken.Expires > DateTime.Now)
                {
                    return refreshToken;
                }
            }

            return null;
        }

    }
}

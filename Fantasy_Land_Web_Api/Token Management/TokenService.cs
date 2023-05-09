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


        public TokenService(FantasyLandDbContext dbContext, JwtConfig jwtConfig, UserManager<User> userManager)
        {
            this._dbContext = dbContext;
            this._jwtConfig = jwtConfig;
            this._userManager = userManager;
        }

        public async Task<string> GetAccessTokenAsync(string refreshToken)
        {
            // Not implemented in this example
            // You could implement this method to get the access token from the server using the refresh token
            // You can use the HttpClientFactory to create a new HttpClient and send a request to the server to get the access token
            // The implementation could be similar to RefreshAccessTokenAsync but without refreshing the token
            throw new NotImplementedException();
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

            //var roles = await _userManager.GetRolesAsync(user);

            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, user.UserName),
            //    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            //};

            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            //var accessToken = GenerateAccessToken(claims);


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

        private async Task<RefreshToken> UpdateRefreshTokenAsync(string userid)
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

            //Token descriptor

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    //new Claim(type:"Id", value:user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddHours(1),
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

        public Task<string> RefreshRefreshTokenAsync(string userid, string refreshToken)
        {
            throw new NotImplementedException();
        }

        Task<RefreshToken> ITokenService.UpdateRefreshTokenAsync(string userid)
        {
            throw new NotImplementedException();
        }
    }
}

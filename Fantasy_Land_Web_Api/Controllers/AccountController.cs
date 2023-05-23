using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Models.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Fantasy_Land_Web_Api.Interfaces;
using Models.Entities;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly FantasyLandDbContext _dbContext;
        private readonly JwtConfig _jwtConfig;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager, FantasyLandDbContext dbContext, JwtConfig jwtConfig, ITokenService tokenService)
        {
            this._userManager = userManager;
            this._dbContext = dbContext;
            this._jwtConfig = jwtConfig;
            this._tokenService = tokenService;
        }

        private bool IsRevoked(RefreshToken refreshToken)
        {
            bool isRevoked = false;

            if (refreshToken != null)
            {
                if (refreshToken.IsRevoked)
                {
                    isRevoked = true;
                }
            }
            return isRevoked;
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {

            Response.Cookies.Delete(Constants.XAccessToken, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true
            });

            Response.Cookies.Delete(Constants.XRefreshToken, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true
            });

            return Ok();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                //Check if user exist

                var existing_user = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName.Equals(requestDto.Username));

                if (existing_user == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid payload"
                        },
                        Result = false
                    });

                }

                var isCorrect = await _userManager.CheckPasswordAsync(existing_user, requestDto.Password);

                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                            {
                                "Invalid credentials"
                            },
                        Result = false
                    });
                }

                var refreshToken = await _tokenService.GetRefreshTokenAsync(existing_user.Id);

                if (refreshToken == null)
                {
                    refreshToken = new RefreshToken
                    {
                        UserId = existing_user.Id,
                        Token = _tokenService.GenerateRefreshToken(),
                        Expires = DateTime.Now.AddMinutes(_jwtConfig.RefreshTokenExpiration),
                        RemoteIpAddress = requestDto.RemoteIpAddress
                    };

                    await _dbContext.RefreshTokens.AddAsync(refreshToken);
                    await _dbContext.SaveChangesAsync();
                }

                else if (refreshToken.IsRevoked)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Refresh token has been revoked"
                        },
                        Result = false
                    });
                }

                else if (refreshToken.Expires < DateTime.Now)
                {
                    refreshToken.Token = _tokenService.GenerateRefreshToken();
                    refreshToken.Expires = DateTime.Now.AddMinutes(_jwtConfig.RefreshTokenExpiration);

                    await _tokenService.UpdateRefreshTokenAsync(existing_user.Id);
                    await _dbContext.SaveChangesAsync();
                }

                var authResult = _tokenService.GenerateAccessToken(existing_user);

                Response.Cookies.Append(Constants.XAccessToken, authResult.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                });

                Response.Cookies.Append(Constants.XRefreshToken, refreshToken.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddMinutes(_jwtConfig.RefreshTokenExpiration),
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                });

                var refreshTokenResponse = new RefreshTokenResponseDto
                {
                    AccessToken = authResult.AccessToken,
                    RefreshToken = refreshToken.Token,
                    Expires = refreshToken.Expires
                };

                return Ok(refreshTokenResponse);

            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid payload"
                },
                Result = false
            });
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            //Validate incoming request

            if (ModelState.IsValid)
            {
                //check if username already exists
                var user_exist = _dbContext.Users.FirstOrDefault(p => p.UserName.Equals(requestDto.Username));

                if (user_exist != null)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Username already exist"
                        }
                    });
                }

                //create user

                var new_user = new User()
                {

                    FirstName = requestDto.FirstName,
                    LastName = requestDto.LastName,
                    Gender = requestDto.Gender,
                    UserName = requestDto.Username,
                    IsPrivate = requestDto.IsPrivate,
                    RememberMe = requestDto.RememberMe
                };

                var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);

                if (is_created.Succeeded)
                {
                    //Generate token

                    AuthResult authResult = _tokenService.GenerateAccessToken(new_user);


                    _dbContext.Users.Add(new_user);

                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Errors = null,
                        AccessToken = authResult.AccessToken,
                        Username = authResult.Username
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                        {
                            "Server error"
                        },
                    Result = false
                });
            }

            return BadRequest();

        }

    }
}

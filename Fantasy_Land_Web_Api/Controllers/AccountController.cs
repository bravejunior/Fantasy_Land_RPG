using Fantasy_Land_Web_Api.Configurations;
using Fantasy_Land_Web_Api.Context;
using Fantasy_Land_Web_Api.Models;
using Fantasy_Land_Web_Api.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly FantasyLandDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, FantasyLandDbContext dbContext, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._dbContext = dbContext;
            this._configuration = configuration;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                //Check if user exist

                var existing_user = _userManager.Users.FirstOrDefault(p => p.UserName.Equals(requestDto.Username));

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

                var jwtToken = GenerateJwtToken(existing_user);

                return Ok(new AuthResult()
                {
                    Token = jwtToken.Token,
                    Result = true
                });

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
        [Route("Register")]
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

                    var token = GenerateJwtToken(new_user);

                    _dbContext.Users.Add(new_user);
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token.Token
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


        private TokenResponse GenerateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JwtConfig:Secret").Value);

            //Token descriptor

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(type:"Id", value:user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            TokenResponse response = new TokenResponse()
            {
                Token = jwtToken
            };

            return response;
        }
    }
}

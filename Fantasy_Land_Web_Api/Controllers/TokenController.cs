using Fantasy_Land_Web_Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Configurations;
using Models.DTOs;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly JwtConfig _jwtConfig;

        public TokenController(ITokenService tokenService, JwtConfig jwtConfig)
        {
            this._tokenService = tokenService;
            this._jwtConfig = jwtConfig;
        }

        [HttpGet]
        public async Task<IActionResult> RefreshAccessToken(string refreshToken)
        {
            var authResult = await _tokenService.RefreshAccessTokenAsync(refreshToken);

            Response.Cookies.Append(Constants.XAccessToken, authResult.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                SameSite = SameSiteMode.Strict,
                Secure = true
            });

            return Ok();
        }
    }
}

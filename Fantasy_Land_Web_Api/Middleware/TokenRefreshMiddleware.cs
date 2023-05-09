using Fantasy_Land_Web_Api.Interfaces;
using Models.Configurations;
using System.Net.Http.Headers;

namespace Fantasy_Land_Web_Api.Middleware
{
    public class TokenRefreshMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly JwtConfig _jwtConfig;



        public TokenRefreshMiddleware(RequestDelegate next, JwtConfig jwtConfig)
        {
            _next = next;
            _jwtConfig = jwtConfig;
        }

        public async Task InvokeAsync(HttpContext context, ITokenService tokenService)
        {
            await _next(context);

            if (context.Response.StatusCode == 401)
            {
                var refreshToken = context.Request.Cookies[Constants.XRefreshToken];

                if (refreshToken != null)
                {
                    var authResult = await tokenService.RefreshAccessTokenAsync(refreshToken);

                    if (authResult != null)
                    {
                        context.Response.Cookies.Append(Constants.XAccessToken, authResult.AccessToken, new CookieOptions
                        {
                            HttpOnly = true,
                            Expires = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                            SameSite = SameSiteMode.Strict,
                            Secure = true
                        });



                        return;
                    }
                }
            }
        }
    }

}

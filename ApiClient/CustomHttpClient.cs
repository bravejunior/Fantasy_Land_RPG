using System.Net.Http.Headers;
using System.Net;
using Fantasy_Land_Web_Api.Interfaces;
using Models.Configurations;
using Models.DTOs;
using Newtonsoft.Json;

namespace ApiClient
{
    public class CustomHttpClient : HttpClient
    {
        private readonly ITokenService _tokenService;
        private readonly JwtConfig _jwtConfig;

        public CustomHttpClient(ITokenService tokenService, JwtConfig jwtConfig)
        {
            this._jwtConfig = jwtConfig;
            this._tokenService = tokenService;
        }

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {


                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RefreshTokenResponseDto>(responseContent);
                string refreshToken = result.RefreshToken;

                var authResult = await _tokenService.RefreshAccessTokenAsync(refreshToken);

                if (authResult != null)
                {
                    // Update the access token in the request header
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                    // Send the request again with the new access token
                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            return response;
        }
    }

}

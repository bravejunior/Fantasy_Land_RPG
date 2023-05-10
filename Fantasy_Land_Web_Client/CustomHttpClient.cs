using System.Net.Http.Headers;
using System.Net;
using Models.Configurations;
using Models.DTOs;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;

namespace Fantasy_Land_Web_Client
{
    public class CustomHttpClient : HttpClient
    {

        public CustomHttpClient(HttpClientHandler clientHandler) : base(clientHandler)
        {

        }

        public long GetTokenExpirationTime(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
            var ticks = long.Parse(tokenExp);
            return ticks;
        }

        public bool CheckTokenIsValid(string token)
        {
            var tokenTicks = GetTokenExpirationTime(token);
            var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

            var now = DateTime.Now.ToUniversalTime();

            var valid = tokenDate >= now;

            return valid;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpMethod method, string requestUri)
        {
            // Sends the request to the base
            HttpRequestMessage request = new HttpRequestMessage(method, requestUri);
            HttpResponseMessage response = await base.SendAsync(request);

            // If it gets 401 the middleware will add a access token if available, so tries to resend
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                request = new HttpRequestMessage(method, requestUri);
                response = await base.SendAsync(request);
            }

            return response;
        }
        public async Task<AuthResult> GetAuthResultAsync(HttpResponseMessage data)
        {
            string responseContent = await data.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthResult>(responseContent);
        }
    }

}

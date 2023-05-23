using Fantasy_Land_Web_Client.Interfaces;
using Models.Entities;
using Newtonsoft.Json;

namespace Fantasy_Land_Web_Client.Services
{
    public class UserService : IUserService
    {
        private CustomHttpClient _httpclient;
        public UserService(CustomHttpClient httpclient)
        {
            _httpclient = httpclient;
        }


        public async Task<User> GetCurrentUserAsync()
        {
            string requestUri = "api/user/current-user";
            HttpResponseMessage response = await _httpclient.SendAsync(HttpMethod.Get, requestUri);

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(content);
        }
    }
}

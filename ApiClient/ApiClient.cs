using Fantasy_Land_Web_Api.Interfaces;
using Fantasy_Land_Web_Api.Token_Management;
using Microsoft.Extensions.DependencyInjection;
using Models.Configurations;

namespace ApiClient
{
    public static class ApiClient
    {
        public static void ConfigureServices(IServiceCollection services, JwtConfig jwtConfig)
        {
            services.AddSingleton<CustomHttpClient>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton(jwtConfig);
        }
    }
}

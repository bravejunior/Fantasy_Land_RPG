using Fantasy_Land_Web_Client.Action_filters;
using Fantasy_Land_Web_Client.Interfaces;
using Fantasy_Land_Web_Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Models.Configurations;
using System.Net.Http.Headers;

namespace Fantasy_Land_Web_Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var secret = Environment.GetEnvironmentVariable("FANTASY_LAND_SECRET");

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var jwtConfig = new JwtConfig
            {
                Secret = secret,
                AccessTokenExpiration = 1, // set the access token expiration time
                RefreshTokenExpiration = 1440 // set the refresh token expiration time
            };


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(CurrentUserActionFilter));
            });

            builder.Services.AddSingleton(jwtConfig);
            builder.Services.AddScoped<CurrentUserActionFilter>();
            builder.Services.AddScoped<IUserService, UserService>();



            CustomHttpClient client = new CustomHttpClient(clientHandler);
            client.BaseAddress = new Uri("https://localhost:7290/api");

            builder.Services.AddSingleton<CustomHttpClient>(client);
            builder.Services.AddRouting(options => options.LowercaseUrls = true);


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
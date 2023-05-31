using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Configurations;
using System.Text;
using Fantasy_Land_Web_Api.Token_Management;
using Fantasy_Land_Web_Api.Interfaces;
using Fantasy_Land_Web_Api.Middleware;
using Models.Entities;

namespace Fantasy_Land_Web_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

            // Add services to the container.

            builder.Services.AddControllers();
            var secret = Environment.GetEnvironmentVariable("FANTASY_LAND_SECRET");
            var jwtConfig = new JwtConfig
            {
                Secret = secret,
                AccessTokenExpiration = 5, // set the access token expiration time
                RefreshTokenExpiration = 1440 // set the refresh token expiration time
            };

            builder.Services.AddSingleton(jwtConfig);
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<FantasyLandDbContext>();

            builder.Services.AddDbContext<FantasyLandDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            builder.Services.AddAuthentication(configureOptions: options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.Cookie.Name = "token";
            })
                .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(secret);

                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                        ValidAudience = builder.Configuration["JwtSettings:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidateLifetime = true
                    };
                    jwt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies[Constants.XAccessToken];
                            return Task.CompletedTask;
                        }
                    };

                });


            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            });

            //make routing lowercase only
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            app.UseMiddleware<TokenRefreshMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FantasyLand API V0.1");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using Models.DTOs;
using Models.Configurations;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class AccountController : Controller
    {
        private CustomHttpClient _httpclient;
        private readonly JwtConfig _jwtConfig;

        public AccountController(CustomHttpClient httpClient, JwtConfig jwtConfig)
        {
            _httpclient = httpClient;
            _jwtConfig = jwtConfig;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string data = System.Text.Json.JsonSerializer.Serialize(viewModel, options);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpclient.PostAsync($"api/account/register", contentData);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AuthResult>(responseContent);
                    string accessToken = result.AccessToken;

                    var loginViewModel = new UserLoginViewModel
                    {
                        Username = viewModel.Username,
                        Password = viewModel.Password
                    };

                    LogIn(loginViewModel);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return View(viewModel);
                }
            }

            else
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                viewModel.RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                string data = System.Text.Json.JsonSerializer.Serialize(viewModel, options);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpclient.PostAsync($"api/account/login", contentData);


                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<RefreshTokenResponseDto>(responseContent);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(viewModel);
                }
            }

            else
            {
                return View(viewModel);
            }
        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var uri = "api/account/logout";
            HttpResponseMessage response = await _httpclient.GetAsync(uri);

            return RedirectToAction("Index", "Home");
        }

    }
}

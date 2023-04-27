using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Fantasy_Land_Web_Client.Models;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class AccountController : Controller
    {
        private HttpClient _httpclient;

        public AccountController(HttpClient httpClient)
        {
            this._httpclient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Claim> ExtractClaims(string jwtToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtToken);
            IEnumerable<Claim> claims = securityToken.Claims;

            return claims;
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
                    string token = result.Token;

                    CreateTokenCookie(token);


                    //var token = HttpContext.Request.Cookies[Constants.XAccessToken];
                    var claims = ExtractClaims(token);



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
        private void CreateTokenCookie(string token)
        {
            HttpContext.Response.Cookies.Append(Constants.XAccessToken, token, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.Strict
            });

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

                string data = System.Text.Json.JsonSerializer.Serialize(viewModel, options);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpclient.PostAsync($"api/account/login", contentData);


                if (response.IsSuccessStatusCode)
                {
                    var token = HttpContext.Request.Cookies[Constants.XAccessToken];
                    var claims = ExtractClaims(token);

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

    }
}

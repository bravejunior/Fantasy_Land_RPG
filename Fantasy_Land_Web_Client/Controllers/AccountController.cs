using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Fantasy_Land_Web_Client.Models;
using System.Text.Json;

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

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string data = JsonSerializer.Serialize(viewModel, options);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpclient.PostAsync($"api/account/register", contentData);

                if (response.IsSuccessStatusCode)
                {
                    return View("Login");
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
        public async Task<IActionResult> LogIn(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string data = JsonSerializer.Serialize(viewModel, options);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpclient.PostAsync($"api/account/login", contentData);

                if (response.IsSuccessStatusCode)
                {
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

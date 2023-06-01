using Fantasy_Land_Web_Client.Interfaces;
using Fantasy_Land_Web_Client.Viewmodels;
using Fantasy_Land_Web_Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.Images;
using System.Diagnostics;
using System.Text.Json;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CustomHttpClient _httpclient;
        private IUserService _userService;

        public HomeController(ILogger<HomeController> logger, CustomHttpClient httpclient, IUserService userService)
        {
            _logger = logger;
            _httpclient = httpclient;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var user = ViewData["CurrentUser"];

            // get all npc portraits
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //HttpResponseMessage response = await _httpclient.GetAsync("api/portrait/npc-portraits");
            //string data = await response.Content.ReadAsStringAsync();
            //var list = JsonSerializer.Deserialize<List<Portrait>>(data, options);

            //var viewModel = new HomeIndexViewModel { NpcPortrait = list };

            //return View(viewModel);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
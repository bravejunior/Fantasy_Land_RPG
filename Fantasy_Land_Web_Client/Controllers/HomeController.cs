using Fantasy_Land_Web_Client.Interfaces;
using Fantasy_Land_Web_Client.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

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

        public async Task<IActionResult> IndexAsync()
        {
            //var user = await _userService.GetCurrentUserAsync();

            var user = ViewData["CurrentUser"];
            return View(user);
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
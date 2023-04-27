using Fantasy_Land_Web_Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpclient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpclient)
        {
            _logger = logger;
            _httpclient = httpclient;
        }

        public async Task<IActionResult> IndexAsync() //Test if token works
        {
            HttpResponseMessage response = await _httpclient.GetAsync("api/character/characters");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //var piss = response.Content.Headers;
                ViewBag.Message = content;
                return View();

            }
            else
            {

                return View();
            }
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
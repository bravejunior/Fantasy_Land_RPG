using ApiClient;
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
        private HttpClient _httpclient;

        public HomeController(ILogger<HomeController> logger, CustomHttpClient httpclient)
        {
            _logger = logger;
            _httpclient = httpclient;
        }

        public async Task<IActionResult> IndexAsync()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "api/character/characters");
            HttpResponseMessage response = await _httpclient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var characters = JsonConvert.DeserializeObject<List<Character>>(content);

                ViewBag.Message = content;
                return View();
            }
            else
            {
                return View();
            }
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
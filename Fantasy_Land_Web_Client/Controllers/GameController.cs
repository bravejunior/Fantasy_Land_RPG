using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using System.Text.Json;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class GameController : Controller
    {
        private CustomHttpClient _httpClient;

        public GameController(CustomHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Route("play")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("create-character")]
        public async Task<IActionResult> CreateCharacterAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            HttpResponseMessage response = await _httpClient.GetAsync("api/game/create-character");
            string data = await response.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<CreateCharacterDataDto>(data, options);

            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/Game/PartialViews/_CreateCharacter.cshtml", dto);
            }
            else
            {
                return PartialView("_MainMenu");
            }
        }

        [Route("main-menu")]
        public async Task<IActionResult> MainMenu()
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/Game/PartialViews/_MainMenu.cshtml");
            }
            else
            {
                return PartialView("_MainMenu");
            }
        }
    }
}

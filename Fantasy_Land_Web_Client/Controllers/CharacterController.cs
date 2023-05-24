using Fantasy_Land_Web_Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using System.Text.Json;

namespace Fantasy_Land_Web_Client.Controllers
{
    [Route("characters")]
    public class CharacterController : Controller
    {
        public CustomHttpClient _httpClient { get; set; }

        public CharacterController(CustomHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("create-character")]
        [HttpPost]
        public async Task<IActionResult> CreateCharacter(CreateCharacterViewModel viewModel)
        {
            var user = (User)ViewData["CurrentUser"];

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid && user.UserName == viewModel.CharacterCreationDto.Username)
            {
                CharacterCreationDto dto = viewModel.CharacterCreationDto;
                dto.Username = viewModel.CharacterCreationDto.Username;
                var uri = "api/character/create-character";

                string data = JsonSerializer.Serialize(viewModel.CharacterCreationDto, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(uri, contentData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.SuccessMessage = viewModel.CharacterCreationDto.CharacterName + " has been created.";
                    ModelState.Clear();
                }
            }

            return View();
        }

        [Route("create-character")]
        public IActionResult CreateCharacter()
        {
            return View();
        }
    }
}

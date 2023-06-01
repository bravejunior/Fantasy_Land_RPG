using Fantasy_Land_Web_Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using Models.Entities._PlayerCharacter;
using Models.Images;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web;

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

        public async Task<IActionResult> IndexAsync()
        {
            var user = (User)ViewData["CurrentUser"];

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var uri = "https://localhost:7290/api/character/characters";
            UriBuilder builder = new UriBuilder(uri);
            builder.Query = "username=" + user.UserName;

            var response = await _httpClient.GetAsync(builder.Uri);
            string responseContent = await response.Content.ReadAsStringAsync();
            var characterList = JsonConvert.DeserializeObject<List<PlayerCharacter>>(responseContent);
            var viewModel = new CharacterIndexViewModel
            {
                Characters = characterList
            };

            return View(viewModel);
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
                var uri = "api/character/create-character";
                CharacterCreationDto dto = viewModel.CharacterCreationDto;
                dto.Username = viewModel.CharacterCreationDto.Username;

                string data = System.Text.Json.JsonSerializer.Serialize(dto, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(uri, contentData);
                var a = await response.Content.ReadAsStringAsync();

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

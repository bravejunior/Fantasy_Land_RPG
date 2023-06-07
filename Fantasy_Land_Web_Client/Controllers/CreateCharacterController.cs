using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities._Profession;
using Models.Images;
using System.Text.Json;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class CreateCharacterController : Controller
    {

        private CustomHttpClient _httpClient;

        public CreateCharacterController(CustomHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<List<Profession>> GetProfessionsAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            HttpResponseMessage response = await _httpClient.GetAsync("api/createcharacter/get-professions");
            string data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Profession>>(data, options);
        }


        [Route("choose-portrait")]
        public async Task<IActionResult> ChoosePortrait()
        {
            var portraits = await GetPortraits();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/CreateCharacter/PartialViews/_ChoosePortrait.cshtml", portraits);
            }
            else
            {
                return PartialView("_Error");
            }
        }

        private async Task<List<Portrait>> GetPortraits()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            HttpResponseMessage response = await _httpClient.GetAsync("api/createcharacter/get-portraits");
            string data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Portrait>>(data, options);
        }

        [Route("choose-attributes")]
        public async Task<IActionResult> ChooseAttributes()
        {
            var attributes = await GetAttributes();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/CreateCharacter/PartialViews/_ChooseAttributes.cshtml", attributes);
            }
            else
            {
                return PartialView("_Error");
            }
        }

        private async Task<List<Models.Entities._Ability.Attribute>> GetAttributes()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            HttpResponseMessage response = await _httpClient.GetAsync("api/createcharacter/get-attributes");
            string data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Models.Entities._Ability.Attribute>>(data, options);
        }

        [Route("choose-profession")]
        public async Task<IActionResult> ChooseProfession()
        {
            var professions = await GetProfessionsAsync();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/CreateCharacter/PartialViews/_ChooseProfession.cshtml", professions);
            }
            else
            {
                return PartialView("_Error");
            }
        }
    }
}

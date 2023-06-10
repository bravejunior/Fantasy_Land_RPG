using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities._Ability;
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

        public async Task<IActionResult> IndexAsync()
        {
            var dto = await GetCreateCharacterDataAsync();
            return View(dto);
        }

        private async Task<CreateCharacterDataDto> GetCreateCharacterDataAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            HttpResponseMessage response = await _httpClient.GetAsync("api/createcharacter/get-character-creation-data");
            string data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CreateCharacterDataDto>(data, options);
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
        public IActionResult ChoosePortrait(List<Portrait> portraits)
        {
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

        private async Task<List<Portrait>> GetPortraitsAsync()
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
        public IActionResult ChooseAttributes(List<Models.Entities._Ability.Attribute> attributes)
        {
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

        private async Task<List<Models.Entities._Ability.Attribute>> GetAttributesAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            HttpResponseMessage response = await _httpClient.GetAsync("api/createcharacter/get-attributes");
            string data = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Models.Entities._Ability.Attribute>>(data, options);

            return list;
        }

        [Route("choose-profession")]
        public IActionResult ChooseProfession(List<Profession> professions)
        {
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

        [Route("choose-capabilities")]
        public IActionResult ChooseCapabilities(List<Capability> capabilities)
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/CreateCharacter/PartialViews/_ChooseCapabilities.cshtml", capabilities);
            }
            else
            {
                return PartialView("_Error");
            }
        }
    }
}

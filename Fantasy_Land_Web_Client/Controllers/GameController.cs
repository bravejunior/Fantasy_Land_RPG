﻿using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using Models.Images;
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

        private async Task<CreateCharacterDataDto> GetCharacterCreationDtoAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            HttpResponseMessage response = await _httpClient.GetAsync("api/game/create-character");
            string data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CreateCharacterDataDto>(data, options);
        }


        [Route("create-character")]
        public async Task<IActionResult> CreateCharacterAsync()
        {
            var dto = await GetCharacterCreationDtoAsync();

            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/Game/PartialViews/_CreateCharacter.cshtml", dto);
            }
            else
            {
                return PartialView("_Error");
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
                return PartialView("_Error");
            }
        }

        [Route("choose-portrait")]
        public async Task<IActionResult> ChoosePortrait()
        {
            var portraits = await GetPortraits();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return PartialView("/Views/Game/PartialViews/_ChoosePortrait.cshtml", portraits);
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
            HttpResponseMessage response = await _httpClient.GetAsync("api/game/get-portraits");
            string data = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Portrait>>(data, options);
        }
    }
}

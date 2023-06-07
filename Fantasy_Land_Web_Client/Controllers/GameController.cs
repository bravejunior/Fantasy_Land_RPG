using Microsoft.AspNetCore.Mvc;
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

        [Route("main-menu")]
        public IActionResult MainMenu()
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


    }
}

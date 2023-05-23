using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Land_Web_Client.Controllers
{
    [Route("play")]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            var user = ViewData["CurrentUser"];

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}

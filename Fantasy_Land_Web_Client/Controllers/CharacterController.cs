using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Land_Web_Client.Controllers
{
    [Route("characters")]
    public class CharacterController : Controller
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

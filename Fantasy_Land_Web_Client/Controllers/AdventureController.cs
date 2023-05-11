using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class AdventureController : Controller
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

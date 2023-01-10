using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Land_Web_Client.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}

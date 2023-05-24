using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Land_Web_Client.Controllers
{
    [Route("play")]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Fantasy_Land_Web_Client.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Fantasy_Land_Web_Client.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IUserService _service;

        public UserViewComponent(IUserService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            User user = await _service.GetCurrentUserAsync();
            if (user != null)
            {
                return View("Default", user);
            }
            else
            {
                return View("Default");
            }
        }
    }
}

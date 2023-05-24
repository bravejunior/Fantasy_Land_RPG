using Fantasy_Land_Web_Client.Interfaces;
using Fantasy_Land_Web_Client.ViewModels;
using Fantasy_Land_Web_Client.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models.Entities;

namespace Fantasy_Land_Web_Client.Action_filters
{
    public class CurrentUserActionFilter : IAsyncActionFilter
    {
        private readonly IUserService _userService;
        private readonly IViewComponentHelper _viewComponentHelper;

        public CurrentUserActionFilter(IUserService userService, IViewComponentHelper viewComponentHelper)
        {
            _userService = userService;
            _viewComponentHelper = viewComponentHelper;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user != null)
            {
                context.HttpContext.Items["CurrentUser"] = user;
                ((Controller)context.Controller).ViewData["CurrentUser"] = user;
                //await UpdateViewComponent(user);
            }

            await next();
        }

        //private async Task UpdateViewComponent(User user)
        //{
        //    var viewComponentResult = await _viewComponentHelper.InvokeAsync("UserViewComponent", user);
        //    int a = 1;
        //}
    }
}

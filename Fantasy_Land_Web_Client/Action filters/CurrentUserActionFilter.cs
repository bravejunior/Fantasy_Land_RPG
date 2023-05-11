using Fantasy_Land_Web_Client.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fantasy_Land_Web_Client.Action_filters
{
    public class CurrentUserActionFilter : IAsyncActionFilter
    {
        private readonly IUserService _userService;

        public CurrentUserActionFilter(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = await _userService.GetCurrentUserAsync();
            if (user != null)
            {
                context.HttpContext.Items["CurrentUser"] = user;
                ((Controller)context.Controller).ViewData["CurrentUser"] = user;
            }

            await next();
        }
    }
}

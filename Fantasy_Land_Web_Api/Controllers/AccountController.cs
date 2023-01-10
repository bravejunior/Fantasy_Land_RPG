using Fantasy_Land_Web_Api.Context;
using Fantasy_Land_Web_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<User> _signInManager;
        private FantasyLandDbContext _dbContext;
        private UserManager<User> _userManager;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, FantasyLandDbContext dbContext)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                User user = new User();

                user.FirstName = registerViewModel.FirstName;
                user.LastName = registerViewModel.LastName;
                user.Gender = registerViewModel.Gender;
                user.UserName = registerViewModel.Username;
                user.IsPrivate = registerViewModel.IsPrivate;

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    _dbContext.Users.Add(user);
                    return Ok(user);
                }

                else
                {
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                return BadRequest("Not able to register, please try again.");
            }

            _dbContext.SaveChanges();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, isPersistent: true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }

            }

            return BadRequest("Something went wrong");
        }
    }
}

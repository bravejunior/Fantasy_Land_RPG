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
        public async Task<IActionResult> Register(UserRegisterViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                User user = new User();

                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Gender = viewModel.Gender;
                user.UserName = viewModel.Username;
                user.IsPrivate = viewModel.IsPrivate;
                user.RememberMe = viewModel.RememberMe;

                var result = await _userManager.CreateAsync(user, viewModel.Password);

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
        public async Task<IActionResult> LogIn(UserLoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                //fixa ispersistent beroende på vad usern har valt
                var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, isPersistent: true, lockoutOnFailure: false);


                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }

                return BadRequest(result.ToString());

            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}

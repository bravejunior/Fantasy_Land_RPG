using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace Fantasy_Land_Web_Api.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly FantasyLandDbContext _dbContext;

        public UserController(FantasyLandDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public User GetUser(string userId)
        {
            return _dbContext.Users.FirstOrDefault(p => p.Id == userId);
        }
    }
}

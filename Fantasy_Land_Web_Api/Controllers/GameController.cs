using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly FantasyLandDbContext _dbContext;

        public GameController(FantasyLandDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Route("test")]
        [HttpGet]
        public async Task<string> Test()
        {
            return "Yeah that works";
        }


    }
}

using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Mvc;
using Models.Images;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/npc-portrait")]
    [ApiController]
    public class PortraitController : ControllerBase
    {
        private FantasyLandDbContext _dbContext;
        public PortraitController(FantasyLandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("npc-portraits")]
        public List<Portrait> GetAllNpcPortraits()
        {
            return _dbContext.Portraits.Where(p => p.CharacterClass == null).ToList();
        }

        [HttpGet]
        [Route("player-portrait")]
        public List<Portrait> GetAllPlayerPortraits()
        {
            return _dbContext.Portraits.Where(p => p.CharacterClass != null).ToList();
        }
    }
}

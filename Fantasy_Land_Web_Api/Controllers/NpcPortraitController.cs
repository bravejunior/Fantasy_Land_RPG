using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Mvc;
using Models.Images;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/npc-portrait")]
    [ApiController]
    public class NpcPortraitController : ControllerBase
    {
        private FantasyLandDbContext _dbContext;
        public NpcPortraitController(FantasyLandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("npc-portraits")]
        public List<NpcPortrait> GetAllPortraits()
        {
            return _dbContext.NpcPortraits.ToList();
        }
    }
}

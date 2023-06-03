using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;

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

        [HttpGet]
        [Route("create-character")]
        public CreateCharacterDataDto GetCreateCharacterData()
        {
            var factions = _dbContext.Factions.ToList();
            var dto = new CreateCharacterDataDto
            {
                Factions = factions
            };

            var faction = new Faction
            {
                Id = 1,
                Name = "Happy Faction",
                Description = "The Happy Faction is a sklfnlkfnkldf ac askdm lasd."
            };

            var factionOne = new Faction
            {
                Id = 2,
                Name = "Sad Faction",
                Description = "The Sad Faction is a sklfnlkfnkldf ac askdm lasd."
            };

            var factionTwo = new Faction
            {
                Id = 3,
                Name = "Angry Faction",
                Description = "The Angry Faction is a sklfnlkfnkldf ac askdm lasd."
            };
            dto.Factions.Add(faction);
            dto.Factions.Add(factionOne);
            dto.Factions.Add(factionTwo);
            return dto;
        }


    }
}

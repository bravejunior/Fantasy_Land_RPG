using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;
using Models.Images;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var dto = new CreateCharacterDataDto();
            var factions = _dbContext.Factions.ToList();
            var professions = _dbContext.Professions.ToList();
            var portraits = _dbContext.Portraits.ToList();
            dto.Factions = factions;
            dto.Professions = professions;
            dto.Portraits = portraits;


            return dto;
        }

        [HttpGet]
        [Route("get-portraits")]
        public List<Portrait> GetAllPortraits()
        {
            return _dbContext.Portraits.ToList();
        }

    }
}

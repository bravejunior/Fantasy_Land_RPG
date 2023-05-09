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
    public class CharacterController : ControllerBase
    {
        private FantasyLandDbContext _dbContext;

        public CharacterController(FantasyLandDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("characters")]
        public List<Character> GetAllCharacters()
        {
            return _dbContext.Characters.ToList();
        }

        [HttpPost]
        [Route("character")]
        public void AddCharacter(Character character)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Characters.Add(character);
                _dbContext.SaveChanges();
            }
        }
    }
}

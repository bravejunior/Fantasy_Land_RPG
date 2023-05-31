using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Characters;

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
        public List<PlayerCharacter> GetCharacters(string username)
        {
            var characters = _dbContext.Characters
                //.Include(c => c.CharacterClass)
                //.ThenInclude(cc => cc.CharacterPortraits)
                .Where(p => p.Owner.UserName.Equals(username))
                .ToList();

            return characters;
        }

        [HttpPost]
        [Route("create-character")]
        public void CreateCharacter(CharacterCreationDto dto)
        {
            User user = _dbContext.Users.FirstOrDefault(p => p.UserName.Equals(dto.Username));

            if (ModelState.IsValid)
            {
                PlayerCharacter character = new PlayerCharacter
                {
                    Name = dto.CharacterName,
                    Gender = dto.Gender,
                    Strength = dto.Strength,
                    Constitution = dto.Constitution,
                    Dexterity = dto.Dexterity,
                    Intelligence = dto.Intelligence,
                    Wisdom = dto.Wisdom,
                    Charisma = dto.Charisma,
                    IsSelected = dto.IsSelected,
                    Owner = user,
                    Level = dto.Level,
                    Experience = dto.Experience,
                    CharacterClass = _dbContext.CharacterClasses.FirstOrDefault(p => p.Name.Equals(dto.ClassName))
                };

                _dbContext.Characters.Add(character);
                _dbContext.SaveChanges();
            }
        }
    }
}

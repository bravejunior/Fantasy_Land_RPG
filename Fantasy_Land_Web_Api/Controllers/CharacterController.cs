using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Models.Entities._PlayerCharacter;
using Models.Entities._Ability;

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
                    Owner = user,
                    Level = dto.Level,
                    Experience = dto.Experience,
                    Profession = _dbContext.Professions.FirstOrDefault(p => p.Name.Equals(dto.ProfessionName)),
                    PlayerCharacterAttributes = new List<PlayerCharacterAttribute>()
                };

                foreach (var name in dto.AttributeNames)
                {
                    var attribute = _dbContext.Attributes.FirstOrDefault(p => p.Name.Equals(name));
                    if (attribute != null)
                    {
                        int p = 0;

                        // get amount of points for each attribute
                        if (dto.AttributePoints.TryGetValue(name, out int value))
                        {
                            p = value;
                        }

                        var characterAttribute = new PlayerCharacterAttribute
                        {
                            PlayerCharacter = character,
                            Attribute = attribute,
                            Points = p
                        };

                        character.PlayerCharacterAttributes.Add(characterAttribute);
                    }
                }

                _dbContext.Characters.Add(character);
                _dbContext.SaveChanges();
            }
        }

    }
}

using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities._Profession;
using Models.Images;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CreateCharacterController : ControllerBase
    {
        private FantasyLandDbContext _dbContext;

        public CreateCharacterController(FantasyLandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("get-professions")]
        public List<Profession> GetCreateCharacterData()
        {
            return _dbContext.Professions.ToList();
        }

        [HttpGet]
        [Route("get-portraits")]
        public List<Portrait> GetAllPortraits()
        {
            return _dbContext.Portraits.ToList();
        }

        [HttpGet]
        [Route("get-attributes")]
        public List<Models.Entities._Ability.Attribute> GetAttributes()
        {
            return _dbContext.Attributes.ToList();
        }
    }
}

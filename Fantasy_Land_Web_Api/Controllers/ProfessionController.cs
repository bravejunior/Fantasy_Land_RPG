using Fantasy_Land_Web_Api.Context;
using Models.Entities._Profession;

namespace Fantasy_Land_Web_Api.Controllers
{
    public class ProfessionController
    {
        private readonly FantasyLandDbContext _dbContext;

        public ProfessionController(FantasyLandDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Profession> GetProfessions()
        {
            return _dbContext.Professions.ToList();
        }
    }
}

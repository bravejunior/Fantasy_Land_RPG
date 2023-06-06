using Fantasy_Land_Web_Api.Context;
using Microsoft.AspNetCore.Mvc;
using Models.Images;

namespace Fantasy_Land_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortraitController
    {
        private readonly FantasyLandDbContext _dbContext;

        public PortraitController(FantasyLandDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public void ImportPortraits()
        {
            string female = "female"; // Set the gender (female or male)
            string male = "male";
            string folderPath = "C:\\Users\\Jonas\\Desktop\\distrea\\images\\Portraits\\LQ"; // Set the folder path

            string[] filePathsFemale = Directory.GetFiles(folderPath, $"{female}_*.png");

            List<Portrait> femalePortraits = filePathsFemale.Select(filePath => new Portrait
            {
                Gender = female,
                ImageData = File.ReadAllBytes(filePath)
            }).ToList();

            string[] filePathsMale = Directory.GetFiles(folderPath, $"{male}_*.png");

            List<Portrait> malePortraits = filePathsMale.Select(filePath => new Portrait
            {
                Gender = male,
                ImageData = File.ReadAllBytes(filePath)
            }).ToList();

            _dbContext.Portraits.AddRange(femalePortraits);
            _dbContext.Portraits.AddRange(malePortraits);
            _dbContext.SaveChanges();
        }
    }
}

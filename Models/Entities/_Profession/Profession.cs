using Models.Entities.Characters;
using Models.Images;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Classes
{
    public class Profession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<ProfessionProgression> ProfessionProgression { get; } = new List<ProfessionProgression>();
        public virtual ICollection<PlayerCharacter> PlayerCharacters { get; set; }

    }
}

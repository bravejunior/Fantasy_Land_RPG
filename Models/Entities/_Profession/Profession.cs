using Models.Entities._Ability;
using Models.Entities._PlayerCharacter;
using Models.Images;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Profession
{
    public class Profession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<ProfessionProgression> ProfessionProgression { get; set; }
        public virtual ICollection<PlayerCharacter> PlayerCharacters { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }

    }
}

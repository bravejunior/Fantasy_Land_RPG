using Models.Entities._Profession;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Ability
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Profession")]
        public int? ProfessionId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public virtual Profession Profession { get; set; }
        public ICollection<PlayerCharacterSkill> PlayerCharacterSkills { get; set; }

    }
}

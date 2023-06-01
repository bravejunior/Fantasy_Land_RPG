using Models.Entities._PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Ability
{
    public class PlayerCharacterSkill
    {
        public int Id { get; set; }
        public string PlayerCharacterID { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public int Points { get; set; }
    }
}

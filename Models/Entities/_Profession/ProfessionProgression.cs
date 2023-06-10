using Models.Entities._Ability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Profession
{
    public class ProfessionProgression
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int AttributePoints { get; set; }
        public int SkillPoints { get; set; }


        public Profession Profession { get; set; }

    }
}

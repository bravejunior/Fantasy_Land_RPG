using Models.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Abilities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }

        public int ProfessionProgressionId { get; set; }
        public ProfessionProgression ProfessionProgression { get; set; }
    }
}

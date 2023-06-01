using Models.Entities._Profession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Ability
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }

        public int? ProfessionProgressionId { get; set; }
        public virtual ProfessionProgression ProfessionProgression { get; set; }
    }
}

using Models.Entities;
using Models.Entities._Ability;
using Models.Entities._Profession;
using Models.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CreateCharacterDataDto
    {
        public List<Profession> Professions { get; set; }

        public List<Portrait> Portraits { get; set; }

        public List<Models.Entities._Ability.Attribute> Attributes { get; set; }

        public List<Capability> Capabilities { get; set; }

        //public string? ChosenProfessionName { get; set; }
        //public Portrait? ChosenPortrait { get; set; }
        //public Dictionary<Attribute, int>? ChosenAttributes { get; set; }
    }
}

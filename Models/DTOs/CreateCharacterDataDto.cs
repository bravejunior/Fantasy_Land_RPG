using Models.Entities;
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
        public List<Faction> Factions { get; set; }

        public List<Profession> Professions { get; set; }

        public List<Portrait> Portraits { get; set; }

        public string? ChosenProfessionName { get; set; }
        public Portrait? ChosenPortrait { get; set; }
    }
}

using Models.Entities;
using Models.Entities._Profession;
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
    }
}

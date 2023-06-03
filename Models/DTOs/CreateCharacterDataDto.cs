using Models.Entities;
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
    }
}

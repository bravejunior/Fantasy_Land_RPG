using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Ability
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PlayerCharacterAttribute> PlayerCharacterAttributes { get; set; }


    }
}

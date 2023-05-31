using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Abilities
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }

    }
}

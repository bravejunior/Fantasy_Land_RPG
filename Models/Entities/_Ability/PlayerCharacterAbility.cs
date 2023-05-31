using Models.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Abilities
{
    public class PlayerCharacterAbility
    {
        public int PlayerCharacterID { get; set; }
        public PlayerCharacter PlayerCharacter { get; set; }
        public int AbilityID { get; set; }
        public Ability Ability { get; set; }
        public int Points { get; set; }





        public ICollection<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }

    }
}

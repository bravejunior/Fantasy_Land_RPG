using Models.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Abilities
{
    public class PlayerCharacterCapability
    {
        public int PlayerCharacterID { get; set; }
        public PlayerCharacter PlayerCharacter { get; set; }
        public int CapabilityID { get; set; }
        public Capability Capability { get; set; }
        public int Points { get; set; }





        public ICollection<PlayerCharacterCapability> PlayerCharacterCapabilities { get; set; }


    }
}

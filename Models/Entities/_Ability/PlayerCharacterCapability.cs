using Models.Entities._PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Ability
{
    public class PlayerCharacterCapability
    {
        public int Id { get; set; }
        public string PlayerCharacterID { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public int CapabilityID { get; set; }
        public virtual Capability Capability { get; set; }
        public int Points { get; set; }


    }
}

using Models.Entities._PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Ability
{
    public class PlayerCharacterAttribute
    {
        public int Id { get; set; }
        public string PlayerCharacterID { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public int AttributeId { get; set; }
        public virtual Attribute Attribute { get; set; }
        public int Points { get; set; }


    }
}

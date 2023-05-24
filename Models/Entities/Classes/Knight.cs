using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Classes
{
    public class Knight : CharacterClass
    {
        public int CharismaBonus { get; set; }
    }
}

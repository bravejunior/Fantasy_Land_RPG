using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Classes
{
    public class Berserker : Knight
    {
        public int DamageBonus { get; set; }
        public int DefencePenalty { get; set; }
    }
}

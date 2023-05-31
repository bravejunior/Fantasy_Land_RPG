using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Classes
{
    public class ProfessionProgression
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Points { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }



        // classid & skillid

    }
}

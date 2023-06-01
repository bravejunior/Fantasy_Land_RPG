using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Item
{
    public class ItemLocation
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool Equipped { get; set; }






        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}

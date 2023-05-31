using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Item
{
    public class ItemStats
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public string StatType { get; set; }
        public int Value { get; set; }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities._Item
{
    public class ItemRequirement
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public string RequirementType { get; set; }
        public string RequirementValue { get; set; }
    }
}

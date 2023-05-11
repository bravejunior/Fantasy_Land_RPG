using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Token_management
{
    public class BlacklistedAccessTokens
    {
        public int Id { get; set; }
        public string AcessToken { get; set; }
    }
}

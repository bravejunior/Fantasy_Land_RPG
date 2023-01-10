using Microsoft.AspNetCore.Identity;

namespace Fantasy_Land_Web_Client.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

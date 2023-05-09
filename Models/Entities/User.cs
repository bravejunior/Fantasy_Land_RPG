using Microsoft.AspNetCore.Identity;

namespace Models.DTOs
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public bool RememberMe { get; set; }

        public bool IsPrivate { get; set; }
    }
}

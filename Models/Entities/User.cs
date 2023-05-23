using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public bool RememberMe { get; set; }

        public bool IsPrivate { get; set; }


        public virtual ICollection<Character> Characters { get; set; }


    }
}

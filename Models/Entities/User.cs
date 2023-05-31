using Microsoft.AspNetCore.Identity;
using Models.Entities.Characters;

namespace Models.Entities
{
    public class User : IdentityUser
    {

        public bool RememberMe { get; set; }

        public bool IsPrivate { get; set; }


        public virtual ICollection<PlayerCharacter> Characters { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class User : IdentityUser
    {

        public bool RememberMe { get; set; }

        public bool IsPrivate { get; set; }


        public virtual ICollection<Character> Characters { get; set; }


    }
}

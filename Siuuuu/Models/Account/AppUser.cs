﻿using Microsoft.AspNetCore.Identity;

namespace Siuuuu.Models.Account
{

    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

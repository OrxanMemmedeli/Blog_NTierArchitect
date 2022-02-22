using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser
    {
        public string NameSurname { get; set; }
        public string ImageURL { get; set; }
    }
}

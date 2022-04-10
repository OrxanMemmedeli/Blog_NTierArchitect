using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public bool Status { get; set; }

        public List<Blog> Blogs { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
        public virtual ICollection<Message> Sender { get; set; }
        public virtual ICollection<Message> Receiver { get; set; }

    }
}

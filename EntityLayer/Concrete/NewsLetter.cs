using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class NewsLetter
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int ID { get; set; }
        public string DetailsFirst { get; set; }
        public string DetailsSecond { get; set; }
        public string ImageFirst { get; set; }
        public string ImageSecond { get; set; }
        public string Map { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        
        public bool Status { get; set; } = true;


        [NotMapped]
        public IFormFile FileFirst { get; set; }

        [NotMapped]
        public IFormFile FileSecond { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string MyLocation { get; set; }
        public bool Status { get; set; }
    }
}

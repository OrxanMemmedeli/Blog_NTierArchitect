using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Category
    {

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public bool Status { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
 
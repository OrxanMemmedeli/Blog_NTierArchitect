using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Blog
    {

        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;

        public int CategoryID { get; set; }
        public int? WriterID { get; set; }

        public Category Category { get; set; }
        public AppUser Writer { get; set; }
        public List<Comment> Comments { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public IFormFile ThumbnailImageFile { get; set; }

    }
}

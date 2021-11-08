using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Models.ViewModels
{
    public class WriterDataUpdate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OldPassword { get; set; }
        public bool Status { get; set; }

        public static implicit operator WriterDataUpdate(EntityLayer.Concrete.Writer model)
        {
            return new WriterDataUpdate
            {
                ID = model.ID,
                Name = model.Name,
                About = model.About,
                Image = model.Image,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Status = model.Status,
            };
        }

        public static implicit operator EntityLayer.Concrete.Writer(WriterDataUpdate model)
        {
            return new EntityLayer.Concrete.Writer
            {
                ID = model.ID,
                Name = model.Name,
                About = model.About,
                Image = model.Image,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                Status = model.Status,
            };
        }
    }
}

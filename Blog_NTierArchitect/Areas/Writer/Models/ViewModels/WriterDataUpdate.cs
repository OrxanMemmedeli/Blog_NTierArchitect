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
        public string UserName { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OldPassword { get; set; }
        public bool Status { get; set; }

        public static implicit operator WriterDataUpdate(EntityLayer.Concrete.AppUser model)
        {
            return new WriterDataUpdate
            {
                ID = model.Id,
                Name = model.NameSurname,
                About = model.About,
                Image = model.ImageUrl,
                Email = model.Email,
                Password = model.PasswordHash,
                Status = model.Status,
                UserName = model.UserName
            };
        }

        public static implicit operator EntityLayer.Concrete.AppUser(WriterDataUpdate model)
        {
            return new EntityLayer.Concrete.AppUser
            {
                Id = model.ID,
                NameSurname = model.Name,
                About = model.About,
                ImageUrl = model.Image,
                Email = model.Email,
                PasswordHash = model.Password,
                Status = model.Status,
                UserName = model.UserName
            };
        }
    }
}

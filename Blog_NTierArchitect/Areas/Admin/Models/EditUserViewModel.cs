using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        [Required(ErrorMessage = "Ad Soyad boş ola bilməz.")]
        public string NameSurname { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "İstifadəçi adi boş ola bilməz.")] 
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email boş ola bilməz.")] 
        [EmailAddress(ErrorMessage = "Email düzgün daxil edilməyib.")]
        public string Email { get; set; }
        public string About { get; set; }
        public bool Status { get; set; }

        public static implicit operator AppUser(EditUserViewModel model)
        {
            return new AppUser()
            {
                NameSurname = model.NameSurname,
                ImageUrl = model.Image,
                UserName = model.UserName,
                Email = model.Email,
                About = model.About,
                Status = model.Status
            };
        }

        public static implicit operator EditUserViewModel(AppUser model)
        {
            return new EditUserViewModel()
            {
                NameSurname = model.NameSurname,
                Image = model.ImageUrl,
                UserName = model.UserName,
                Email = model.Email,
                About = model.About,
                Status = model.Status
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Models.ViewModels
{
    public class UserSignInViewModel
    {
        [Display(Name = "İstifadəçi adı")]
        [Required(ErrorMessage = "İstifadəçi adı boş ola bilməz")]
        public string UserName { get; set; }

        [Display(Name = "Şifrə")]
        [Required(ErrorMessage = "Şifrə boş ola bilməz")]
        public string Password { get; set; }
    }
}

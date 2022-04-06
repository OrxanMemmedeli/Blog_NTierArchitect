using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Models.ViewModels
{
    public class UserSingUpViewModel
    {
        [Display(Name = "Ad və Soyadınız")]
        [Required(ErrorMessage = "Ad və Soyad boş ola bilməz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifrə")]
        [Required(ErrorMessage = "Şifrə boş ola bilməz")]
        public string Password { get; set; }

        [Display(Name = "Şifrə təkrarı")]
        [Compare("Password", ErrorMessage = "Şifrələr arası uyğunsuzluq")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email düzgün yazılmayıb")]
        [Required(ErrorMessage = "Email boş ola bilməz")]
        public string Email { get; set; }

        [Display(Name = "İstifadəçi adı")]
        [Required(ErrorMessage = "İstifadəçi adı boş ola bilməz")]
        public string UserName { get; set; }

        [Display(Name = "Qeydiyyat şərtləri")]
        [Range(typeof(bool), "true", "true", ErrorMessage ="Qeydiyyat şərtləri qəbul edilməmişdir")]
        public bool IsAcceptRules { get; set; }
    }
}

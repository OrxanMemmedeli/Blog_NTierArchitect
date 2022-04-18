using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Models
{
    public class EditPasswordViewModel
    {
        [Required(ErrorMessage = "Cari şifrə boş ola bilməz.")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Yeni şifrə boş ola bilməz.")] 
        public string NewPassword { get; set; }

    }
}

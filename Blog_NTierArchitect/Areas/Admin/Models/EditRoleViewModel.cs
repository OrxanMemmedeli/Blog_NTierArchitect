using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Models
{
    public class EditRoleViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Rol boş ola bilməz.")]
        public string Name { get; set; }
    }
}

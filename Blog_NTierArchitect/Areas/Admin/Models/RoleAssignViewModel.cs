using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Exists { get; set; }
    }
}

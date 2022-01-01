using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Models
{
    public class CategoryChartViewModel
    {
        public string Category { get; set; }
        public int BlogCount { get; set; }
    }
}

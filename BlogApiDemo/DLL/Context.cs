using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.DLL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=ILQAR\SQLEXPRESS01; Database=BlogAPIDemo; Integrated Security = true; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-TROAMS4; Database=BlogAPIDemo; Integrated Security = true; MultipleActiveResultSets = True");
            optionsBuilder.UseSqlServer(@"Server=161.97.166.102; Database=HilalDemoSecond; User Id=orxan; password=Ov!tBg@A2g2jA@Z; Trusted_Connection=False; MultipleActiveResultSets=true;");
        }

        public DbSet<Employee> Employees { get; set; }

    }
}

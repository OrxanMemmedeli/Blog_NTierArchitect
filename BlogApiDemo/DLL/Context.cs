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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TROAMS4; Database=BlogAPIDemo; Integrated Security = true; MultipleActiveResultSets = True");
        }

        public DbSet<Employee> Employees { get; set; }

    }
}

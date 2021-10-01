using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.Context
{
    class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ILQAR\SQLEXPRESS01; Database=Blog; Integrated Security = true; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-TROAMS4; Database=Blog; Integrated Security = true; MultipleActiveResultSets = True");
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }

    }

}

using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccessLayer.Concrete.Context
{
    public class BlogContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=ILQAR\SQLEXPRESS01; Database=Blog; Integrated Security = true; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-TROAMS4; Database=Blog; Integrated Security = true; MultipleActiveResultSets = True");
            //optionsBuilder.UseSqlServer(@"workstation id=CoreBlog.mssql.somee.com;packet size=4096;user id=OrkhanCore_SQLLogin_1;pwd=9gc1b4uvm8;data source=CoreBlog.mssql.somee.com;persist security info=False;initial catalog=CoreBlog; MultipleActiveResultSets = True");
            optionsBuilder.UseSqlServer(@"Server=161.97.166.102; Database=HilalDemoFirst; User Id=orxan; password=Ov!tBg@A2g2jA@Z; Trusted_Connection=False; MultipleActiveResultSets=true;");

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(x => x.Sender)
                .HasForeignKey(x => x.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);            

            modelBuilder.Entity<Message>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(x => x.Receiver)
                .HasForeignKey(x => x.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogScore> BlogScores { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }

}

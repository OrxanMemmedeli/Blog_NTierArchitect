using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetAllWithRelationships()
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetAllWithRelationshipsByWriter(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
            }
        }
    }
}

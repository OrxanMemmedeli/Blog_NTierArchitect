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
    public class EFCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetAllWithBlog()
        {
            using (var context = new  BlogContext())
            {
                return context.Comments.Include(x => x.Blog).ToList();
            }
        }

        public Comment GetByIdWithBlog(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Comments.Include(x => x.Blog).FirstOrDefault(x => x.ID == id);
            }
        }
    }
}

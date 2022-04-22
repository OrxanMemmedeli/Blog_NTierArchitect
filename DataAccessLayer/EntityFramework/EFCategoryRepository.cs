using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        BlogContext context = new BlogContext();

        public List<Category> GetAllWithBlog()
        {
            return context.Categories.Include(x => x.Blogs).ToList();
        }

        public List<Category> GetAllWithBlog(Expression<Func<Category, bool>> filter)
        {
            var categories = context.Categories.Include(x => x.Blogs).Where(filter).ToList();
            return categories;
        }
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        List<Category> GetAllWithBlog();
        List<Category> GetAllWithBlog(Expression<Func<Category, bool>> filter);
    }
}

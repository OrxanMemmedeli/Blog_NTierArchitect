using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<Category> GetAllWithBlog();
        List<Category> GetAllWithBlog(Expression<Func<Category, bool>> filter);
    }
}

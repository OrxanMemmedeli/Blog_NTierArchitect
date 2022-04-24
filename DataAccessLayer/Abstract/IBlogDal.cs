using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetAllWithRelationships();
        List<Blog> GetAllWithRelationshipsByWriter(int id);
        List<Blog> GetLastBlogs(int count);
        List<Blog> GetAllWithCategoryAndComments();
        List<Blog> GetAllWithCategoryAndComments(Expression<Func<Blog, bool>> filter);
        Blog GetByIDWithComments(int id);
        List<Blog> SerachData(List<Blog> blogs, string data);
    }
}

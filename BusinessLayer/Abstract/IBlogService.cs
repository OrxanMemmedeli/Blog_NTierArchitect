using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetAllWithRelationships();
        List<Blog> GetAllWithRelationshipsByWriter(int id);
        List<Blog> GetAllWithByWriter(int id);
        List<Blog> GetBlogByID(int id);
        Blog GetByIDWithComments(int id);
        List<Blog> GetLastPosts(int count);
        List<Blog> GetAllWithCategoryAndComments();
        List<Blog> GetAllWithCategoryAndComments(Expression<Func<Blog, bool>> filter);
        List<Blog> SerachData(List<Blog> blogs, string data);
    }
}

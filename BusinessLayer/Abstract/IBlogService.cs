using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetAllWithRelationships();
        List<Blog> GetAllWithRelationshipsByWriter(int id);
        List<Blog> GetAllWithByWriter(int id);
        List<Blog> GetBlogByID(int id);
        List<Blog> GetLastPosts(int count);
    }
}

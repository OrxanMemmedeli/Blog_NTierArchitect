using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetAllWithRelationships();
        List<Blog> GetAllWithRelationshipsByWriter(int id);
        List<Blog> GetLastBlogs(int count);
    }
}

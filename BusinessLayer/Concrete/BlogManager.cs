using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void BlogAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void BlogDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void BlogUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAllWithRelationships()
        {
            return _blogDal.GetAllWithRelationships();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetAll(x => x.ID == id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }
    }
}

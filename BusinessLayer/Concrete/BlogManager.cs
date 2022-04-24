using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Add(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAll(Expression<Func<Blog, bool>> Filter)
        {
            return _blogDal.GetAll(Filter);
        }

        public List<Blog> GetAllWithByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterID == id);
        }

        public List<Blog> GetAllWithCategoryAndComments()
        {
            return _blogDal.GetAllWithCategoryAndComments();
        }

        public List<Blog> GetAllWithCategoryAndComments(Expression<Func<Blog, bool>> filter)
        {
            return _blogDal.GetAllWithCategoryAndComments(filter);
        }

        public List<Blog> GetAllWithRelationships()
        {
            return _blogDal.GetAllWithRelationships();
        }

        public List<Blog> GetAllWithRelationshipsByWriter(int id)
        {
            return _blogDal.GetAllWithRelationshipsByWriter(id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetAll(x => x.ID == id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public Blog GetByIDWithComments(int id)
        {
            return _blogDal.GetByIDWithComments(id);
        }

        public List<Blog> GetLastPosts(int count)
        {
            return _blogDal.GetAll().OrderByDescending(x => x.CreatedDate).Take(count).ToList();
        }

        public List<Blog> SerachData(List<Blog> blogs, string data)
        {
            return _blogDal.SerachData(blogs, data);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}

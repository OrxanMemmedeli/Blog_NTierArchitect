using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void Delete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> Filter)
        {
            return _categoryDal.GetAll(Filter);
        }

        public List<Category> GetAllWithBlog()
        {
            return _categoryDal.GetAllWithBlog();
        }

        public List<Category> GetAllWithBlog(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.GetAllWithBlog(filter);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }
        public void Add(T t)
        {
            _genericDal.Insert(t);
        }

        public void Delete(T t)
        {
            _genericDal.Delete(t);
        }

        public List<T> GetAll()
        {
            return _genericDal.GetAll();
        }

        public List<T> GetAll(Expression<Func<T, bool>> Filter)
        {
            return _genericDal.GetAll(Filter);
        }

        public T GetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public void Update(T t)
        {
            _genericDal.Update(t);
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About t)
        {
            _aboutDal.Insert(t);
        }

        public void Delete(About t)
        {
            _aboutDal.Delete(t);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public List<About> GetAll(Expression<Func<About, bool>> Filter)
        {
            return _aboutDal.GetAll(Filter);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void Update(About t)
        {
            _aboutDal.Update(t);
        }
    }
}

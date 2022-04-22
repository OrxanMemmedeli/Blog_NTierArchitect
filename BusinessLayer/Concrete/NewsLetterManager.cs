using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void Add(NewsLetter t)
        {
            _newsLetterDal.Insert(t);
        }

        public void Delete(NewsLetter t)
        {
            _newsLetterDal.Delete(t);
        }

        public List<NewsLetter> GetAll()
        {
            return _newsLetterDal.GetAll();
        }

        public List<NewsLetter> GetAll(Expression<Func<NewsLetter, bool>> Filter)
        {
            return _newsLetterDal.GetAll(Filter);
        }

        public NewsLetter GetById(int id)
        {
            return _newsLetterDal.GetById(id);
        }

        public bool UniqueEmailControl(string email)
        {
            return _newsLetterDal.UniqueEmailControl(email);
        }

        public void Update(NewsLetter t)
        {
            _newsLetterDal.Update(t);
        }
    }
}

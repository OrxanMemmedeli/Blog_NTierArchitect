using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetAll()
        {
            throw new NotImplementedException();
        }

        public NewsLetter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NewsLetter t)
        {
            throw new NotImplementedException();
        }
    }
}

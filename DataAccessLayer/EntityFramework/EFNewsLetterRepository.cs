using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFNewsLetterRepository : GenericRepository<NewsLetter>, INewsLetterDal
    {
        public bool UniqueEmailControl(string email)
        {
            bool result = false;
            using (var context = new BlogContext())
            {
                result = context.NewsLetters.Any(x => x.Email == email);
            }
            return result;
        }
    }
}

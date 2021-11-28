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
    public class EFWriterRepository : GenericRepository<Writer>, IWriterDal
    {
        private readonly BlogContext context;
        public EFWriterRepository()
        {
            context = new BlogContext();
        }

        public Writer GetWriter(string Email)
        {
            return context.Writers.FirstOrDefault(x => x.Email == Email && x.Status == true);
        }
    }
}

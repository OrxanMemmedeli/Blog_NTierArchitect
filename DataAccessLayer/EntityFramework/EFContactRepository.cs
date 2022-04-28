using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactRepository : GenericRepository<Contact>, IContactDal
    {
        BlogContext context = new BlogContext();

        public void DeleteRange(List<Contact> contacts)
        {
            context.Contacts.RemoveRange(contacts);
            context.SaveChanges();
        }
        public void UpdateRange(List<Contact> contacts)
        {
            context.UpdateRange(contacts);
            context.SaveChanges();
        }
    }
}

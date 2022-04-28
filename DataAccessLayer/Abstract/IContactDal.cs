using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IContactDal : IGenericDal<Contact>
    {
        void UpdateRange(List<Contact> contacts);
        void DeleteRange(List<Contact> contacts);
    }
}

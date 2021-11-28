using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        List<Writer> GetWritersByID(int id);
        Writer GetWriter(string Email);
    }
}

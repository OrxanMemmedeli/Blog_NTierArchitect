using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> Filter);
        T GetById(int id);
    }
}

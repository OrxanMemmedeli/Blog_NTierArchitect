using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        BlogContext context = new BlogContext();
        public async void Delete(T t)
        {
            context.Remove(t);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async void Insert(T t)
        {
            await context.AddAsync(t);
            await context.SaveChangesAsync();
        }

        public async void Update(T t)
        {
            context.Update(t);
            await context.SaveChangesAsync();
        }
    }
}

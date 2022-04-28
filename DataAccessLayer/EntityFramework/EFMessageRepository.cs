using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessageRepository : GenericRepository<Message>, IMessageDal
    {
        BlogContext context = new BlogContext();

        public void DeleteRange(List<Message> messages)
        {
            context.Messages.RemoveRange(messages);
            context.SaveChanges();
        }
        public void UpdateRange(List<Message> messages)
        {
            context.UpdateRange(messages);
            context.SaveChanges();
        }
        public List<Message> GetAllWithWriter(Expression<Func<Message, bool>> filter)
        {
            return context.Messages.Include(x => x.ReceiverUser).Include(x => x.SenderUser).Where(filter).ToList();
        }
        public List<Message> GetAllWithWriter()
        {
            return context.Messages.Include(x => x.ReceiverUser).Include(x => x.SenderUser).ToList();
        }

        public Message GetOneWithWriter(Expression<Func<Message, bool>> filter)
        {
            return context.Messages.Include(x => x.ReceiverUser).Include(x => x.SenderUser).FirstOrDefault(filter);
        }


    }
}

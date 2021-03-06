using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetAllWithWriter(Expression<Func<Message, bool>> filter);
        List<Message> GetAllWithWriter();
        Message GetOneWithWriter(Expression<Func<Message, bool>> filter);
        void UpdateRange(List<Message> messages);
        void DeleteRange(List<Message> messages);
    }
}

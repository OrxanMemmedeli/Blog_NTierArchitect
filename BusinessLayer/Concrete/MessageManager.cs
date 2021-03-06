using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Add(Message t)
        {
            _messageDal.Insert(t);
        }

        public void Delete(Message t)
        {
            _messageDal.Delete(t);
        }

        public void DeleteRange(List<Message> messages)
        {
            _messageDal.DeleteRange(messages);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> Filter)
        {
            return _messageDal.GetAll(Filter);
        }

        public List<Message> GetAllWithWriter(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetAllWithWriter(filter);
        }

        public List<Message> GetAllWithWriter()
        {
            return _messageDal.GetAllWithWriter();
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public Message GetOneWithWriter(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetOneWithWriter(filter);
        }

        public void Update(Message t)
        {
            _messageDal.Update(t);
        }

        public void UpdateRange(List<Message> messages)
        {
            _messageDal.UpdateRange(messages);
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void Delete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetAll(Expression<Func<Notification, bool>> Filter)
        {
            return _notificationDal.GetAll(Filter);
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public void Update(Notification t)
        {
            _notificationDal.Update(t);
        }
    }
}

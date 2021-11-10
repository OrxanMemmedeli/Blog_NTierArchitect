using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents.Writer
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly NotificationManager _notificationManager;
        public NotificationViewComponent()
        {
            _notificationManager = new NotificationManager(new EFNotificationRepository());
        }

        public IViewComponentResult Invoke()
        {
            var notification = _notificationManager.GetAll(x => x.Status == true);
            return View(notification);
        }
    }
}

using BusinessLayer.Abstract;
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
        private readonly INotificationService _notificationService;

        public NotificationViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var notification = _notificationService.GetAll(x => x.Status == true).OrderByDescending(x => x.NotificationDate);
            return View(notification);
        }
    }
}

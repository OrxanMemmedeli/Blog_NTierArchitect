using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class NotificationController : Controller
    {
        private readonly NotificationManager _notificationManager;
        public NotificationController()
        {
            _notificationManager = new NotificationManager(new EFNotificationRepository());
        }

        public IActionResult Index()
        {
            var notifications = _notificationManager.GetAll();
            return View(notifications);
        }
    }
}

using Blog_NTierArchitect.Customattributes;
using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    [CustomAuthorize("Admin, Manager, Writer, User")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            var notifications = _notificationService.GetAll().OrderByDescending(x => x.NotificationDate);
            return View(notifications);
        }

        public IActionResult IsRead(int id)
        {

            var notification = _notificationService.GetById(id);
            notification.Status = false;
            _notificationService.Update(notification);
            return RedirectToAction(nameof(Index));
        }
    }
}

using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly NotificationManager _notificationManager;
        private readonly NotificationValidator _validator;
        public NotificationController()
        {
            _notificationManager = new NotificationManager(new EFNotificationRepository());
            _validator = new NotificationValidator();
        }

        public IActionResult Index()
        {
            var notifications = _notificationManager.GetAll();
            return View(notifications);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Notification notification)
        {
            ValidationResult results = _validator.Validate(notification);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(notification);
            }

            _notificationManager.Add(notification);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Icons()
        {
            return View();
        }

        //public void ()
    }
}

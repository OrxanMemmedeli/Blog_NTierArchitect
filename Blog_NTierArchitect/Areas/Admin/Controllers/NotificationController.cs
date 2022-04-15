using BusinessLayer.Abstract;
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
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            var notifications = _notificationService.GetAll();
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
            if (!ModelState.IsValid)
            {
                return View(notification);
            }

            _notificationService.Add(notification);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = _notificationService.GetById((int)id);

            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return View(notification);
            }

            _notificationService.Update(notification);
            TempData["EditNotification"] = "Məlumat yeniləndi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = _notificationService.GetById((int)id);

            if (notification == null)
            {
                return NotFound();
            }

            _notificationService.Delete(notification);
            TempData["DeleteNotification"] = "Məlumat silindi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Icons()
        {
            return View();
        }

        
    }
}

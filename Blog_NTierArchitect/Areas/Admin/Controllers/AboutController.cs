using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AboutController(IAboutService aboutService, IWebHostEnvironment hostEnvironment)
        {
            _aboutService = aboutService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var abouts = _aboutService.GetAll();
            return View(abouts);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = _aboutService.GetById((int)id);

            if (about == null)
            {
                return NotFound();
            }

            _aboutService.Delete(about);
            TempData["DeleteAbout"] = "Məlumat silindi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Status(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = _aboutService.GetById((int)id);

            if (about == null)
            {
                return NotFound();
            }

            about.Status = !about.Status;

            _aboutService.Update(about);

            TempData["StatusAbout"] = "Status dəyişdirildi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(About about)
        {
            if (about.FileFirst != null)
                UploadImageFirst(about);

            if (about.FileSecond != null)
                UploadImageSecond(about);


            if (ModelState.IsValid)
            {
                _aboutService.Add(about);
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = _aboutService.GetById((int)id);

            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(About about)
        {
            if (about.FileFirst != null)
                UploadImageFirst(about);

            if (about.FileSecond != null)
                UploadImageSecond(about);


            if (ModelState.IsValid)
            {
                _aboutService.Update(about);
                TempData["EditAbout"] = "Məlumat yeniləndi.";
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        private void UploadImageFirst(About about)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(about.FileFirst.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadImages", newImageName);
            if (about.ImageFirst != null)
            {
                System.IO.File.Delete(about.ImageFirst);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                about.ImageFirst = "/UploadImages/" + newImageName;
                about.FileFirst.CopyTo(fileStream);
            }

        }

        private void UploadImageSecond(About about)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(about.FileSecond.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadImages", newImageName);
            if (about.ImageSecond != null)
            {
                System.IO.File.Delete(about.ImageFirst);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                about.ImageSecond = "/UploadImages/" + newImageName;
                about.FileSecond.CopyTo(fileStream);
            }

        }
    }
}

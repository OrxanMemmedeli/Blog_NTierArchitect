using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private readonly WriterManager _writerManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly WriterValidator _validator;

        public WriterController(IWebHostEnvironment webHostEnvironment)
        {
            _writerManager = new WriterManager(new EFWriterRepository());
            _webHostEnvironment = webHostEnvironment;
            _validator = new WriterValidator();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllWriters()
        {
            var writers = _writerManager.GetAll();
            var jsonList = JsonConvert.SerializeObject(writers);
            return Json(jsonList);
        }

        public IActionResult GetWriter(int id)
        {
            var writer = _writerManager.GetById(id);
            var jsonFormat = JsonConvert.SerializeObject(writer);
            return Json(jsonFormat);
        }

        [HttpPost]
        public IActionResult Create(EntityLayer.Concrete.Writer writer)
        {
            ValidationResult results = _validator.Validate(writer);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(writer);
            }
            if (writer.Picture != null)
            {
                UploadImage(writer);
            }

            _writerManager.Add(writer);
            return RedirectToAction(nameof(Index));
        }

        private void UploadImage(EntityLayer.Concrete.Writer writer)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string extension = Path.GetExtension(writer.Picture.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadImages", newImageName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                writer.Image = "/UploadImages/" + newImageName;
                writer.Picture.CopyTo(fileStream);
            }

        }
    }
}

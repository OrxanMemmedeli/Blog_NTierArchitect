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

namespace Blog_NTierArchitect.Controllers
{
    public class AccountController : Controller
    {
        private readonly WriterManager _writerManager;
        private readonly WriterValidator _writerValidator;

        public AccountController()
        {
            _writerManager = new WriterManager(new EFWriterRepository());
            _writerValidator = new WriterValidator();
        }
        public IActionResult Index()
        {
            return View();
        }        
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Writer writer)
        {
            ValidationResult results = _writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writer.Status = true;
                writer.About = "Haqqında məlumat yaz";
                _writerManager.WriterAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(writer);
        }
    }
}

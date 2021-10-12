using Blog_NTierArchitect.Models;
using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            List<City> citys = new List<City>(){
                new City { ID = 1, Name = "Bakı"},
                new City { ID = 2, Name = "Oğuz"},
                new City { ID = 3, Name = "Şəki"},
                new City { ID = 4, Name = "Qəbələ"},
                new City { ID = 5, Name = "Sumqayət"},
                new City { ID = 6, Name = "Şamaxı"},
                new City { ID = 7, Name = "Xızı"},
                new City { ID = 8, Name = "Quba"},
            };

            ViewData["CityID"] = new SelectList(citys, "ID", "Name");

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

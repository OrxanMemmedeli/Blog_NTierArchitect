using Blog_NTierArchitect.Models;
using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly WriterManager _writerManager;
        private readonly WriterValidator _writerValidator;
        private readonly BlogContext _context;
        public AccountController()
        {
            _writerManager = new WriterManager(new EFWriterRepository());
            _writerValidator = new WriterValidator();
            _context = new BlogContext();
        }
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                {
                    return Redirect(ViewBag.ReturnUrl);
                }
                else
                {
                    return Redirect("/Writer");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Writer writer, string returnUrl)
        {

            var user = _context.Writers.SingleOrDefault(u => u.Email == writer.Email && u.Password == writer.Password && u.Status == true);

            if (user != null)
            {

                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Email), // İstifadeci adini yaxalamaq ucun
                            //new Claim(ClaimTypes.Role, user.Role) //Role imkanlari yaratmaq ucun 
                        };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);

                HttpContext.SignInAsync(claimsPrincipal);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/Writer/Dashboard");
                }
            }


            TempData["LoginMessage"] = "Uğursuz əməliyat";

            return View();
        }

        public IActionResult Denied()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login","Account");
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
                _writerManager.Add(writer);
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

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactManager _contactManager;
        public ContactController()
        {
            _contactManager = new ContactManager(new EFContactRepository());
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact model)
        {
            _contactManager.ContactAdd(model);

            TempData["MessageSuccess"] = "Mesajınız qeyde alınmışdır. Mesaj üçün təşəkkür edirik.";
            return View();
        }
    }
}

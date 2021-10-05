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
    public class AccountController : Controller
    {
        private readonly WriterManager _writerManager;
        public AccountController()
        {
            _writerManager = new WriterManager(new EFWriterRepository());
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
            if (writer.Password == writer.ConfirmPassword)
            {
                writer.Status = true;
                writer.About = "Haqqında məlumat yaz";
                _writerManager.WriterAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            return View(writer);
        }
    }
}

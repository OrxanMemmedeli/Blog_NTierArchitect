using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager;
        public AboutController()
        {
            _aboutManager = new AboutManager(new EFAboutRepository());
        }

        public IActionResult Index()
        {
            var aboutDatas = _aboutManager.GetAll();
            return View(aboutDatas);
        }
    }
}

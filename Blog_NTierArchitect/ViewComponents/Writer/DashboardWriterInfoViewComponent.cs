using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Blog_NTierArchitect.ViewComponents.Writer
{
    public class DashboardWriterInfoViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardWriterInfoViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //var writers = Task.Run(async () => await _userManager.Users.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name));            
            AppUser writers = _userManager.Users.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            return View(writers);
        }
    }
}

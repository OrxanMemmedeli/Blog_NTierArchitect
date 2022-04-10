using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var id = Convert.ToInt32(_userManager.GetUserAsync(User));
            var writers = _writerManager.GetWritersByID(_writerManager.GetWriter(User.Identity.Name).ID);
            return View(writers);
        }
    }
}

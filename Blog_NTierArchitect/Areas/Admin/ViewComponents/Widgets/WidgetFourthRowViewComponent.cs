using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.ViewComponents.Widgets
{
    public class WidgetFourthRowViewComponent : ViewComponent
    {
        private readonly AdminManager _adminManager;
        public WidgetFourthRowViewComponent()
        {
            _adminManager = new AdminManager(new EFAdminRepository());
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Admin = _adminManager.GetById(1);
            return View();
        }
    }
}

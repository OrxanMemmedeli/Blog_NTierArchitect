using BusinessLayer.Abstract;
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
        private readonly IAdminService _adminService;

        public WidgetFourthRowViewComponent(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Admin = _adminService.GetById(1);
            return View();
        }
    }
}

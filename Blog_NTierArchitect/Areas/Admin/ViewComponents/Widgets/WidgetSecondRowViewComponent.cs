using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.ViewComponents.Widgets
{
    public class WidgetSecondRowViewComponent : ViewComponent
    {
        private readonly BlogManager _blogManager;
        public WidgetSecondRowViewComponent()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.LastBlog = _blogManager.GetAll().OrderByDescending(x => x.ID).Take(1).First();
            return View();
        }
    }
}

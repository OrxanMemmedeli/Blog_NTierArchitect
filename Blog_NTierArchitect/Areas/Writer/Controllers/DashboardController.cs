using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly CategoryManager _categoryManager;

        public DashboardController()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
            _categoryManager = new CategoryManager(new EFCategoryRepository());
        }

        public IActionResult Index()
        {
            ViewBag.TotalBlog = _blogManager.GetAll().Count();
            ViewBag.TotalCategory = _categoryManager.GetAll().Count();
            ViewBag.BlogsByWriter = _blogManager.GetAllWithByWriter(1).Count();
            return View();
        }
    }
}

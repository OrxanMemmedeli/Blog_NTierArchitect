using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;


        public DashboardController(UserManager<AppUser> userManager)
        {
            _blogManager = new BlogManager(new EFBlogRepository());
            _categoryManager = new CategoryManager(new EFCategoryRepository());
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var id = Convert.ToInt32(_userManager.GetUserId(User));
            ViewBag.TotalBlog = _blogManager.GetAll().Count();
            ViewBag.TotalCategory = _categoryManager.GetAll().Count();
            ViewBag.BlogsByWriter = _blogManager.GetAllWithByWriter(id).Count();
            return View();
        }
    }
}

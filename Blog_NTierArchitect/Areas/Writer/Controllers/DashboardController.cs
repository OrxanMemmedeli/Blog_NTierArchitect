using BusinessLayer.Abstract;
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
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var id = Convert.ToInt32(_userManager.GetUserId(User));
            ViewBag.TotalBlog = _blogService.GetAll().Count();
            ViewBag.TotalCategory = _categoryService.GetAll().Count();
            ViewBag.BlogsByWriter = _blogService.GetAllWithByWriter(id).Count();
            return View();
        }
    }
}

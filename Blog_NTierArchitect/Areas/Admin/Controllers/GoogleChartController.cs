using Blog_NTierArchitect.Areas.Admin.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GoogleChartController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly CategoryManager _categoryManager;

        public GoogleChartController()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
            _categoryManager = new CategoryManager(new EFCategoryRepository());
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CollectChartData()
        {
            List<CategoryChartViewModel> list = new List<CategoryChartViewModel>();

            var blogs = _blogManager.GetAll();
            var categories = _categoryManager.GetAll();

            foreach (var item in categories)
            {
                CategoryChartViewModel model = new CategoryChartViewModel();
                model.Category = item.Name;
                model.BlogCount = blogs.Where(x => x.CategoryID == item.ID).Count();
                list.Add(model);
            }

            return Json(new { jsonlist = list });
        }
    }
}

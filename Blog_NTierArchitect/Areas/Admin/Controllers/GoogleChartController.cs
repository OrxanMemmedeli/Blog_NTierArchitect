using Blog_NTierArchitect.Areas.Admin.Models;
using Blog_NTierArchitect.Customattributes;
using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CustomAuthorize("Admin, Manager")]
    public class GoogleChartController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public GoogleChartController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CollectChartData()
        {
            List<CategoryChartViewModel> list = new List<CategoryChartViewModel>();

            var blogs = _blogService.GetAll();
            var categories = _categoryService.GetAll();

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

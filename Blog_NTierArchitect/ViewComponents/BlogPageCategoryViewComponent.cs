using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class BlogPageCategoryViewComponent : ViewComponent
    {
        private readonly CategoryManager _categoryManager;

        public BlogPageCategoryViewComponent()
        {
            _categoryManager = new CategoryManager(new EFCategoryRepository());
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }
    }
}

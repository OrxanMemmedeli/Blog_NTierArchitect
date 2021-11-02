using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents.Writer
{
    public class DashboardCategoryListViewComponent : ViewComponent
    {
        private readonly CategoryManager _categoryManager;

        public DashboardCategoryListViewComponent()
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

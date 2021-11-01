using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents.Writer
{
    public class DashboardLastPostsViewComponent : ViewComponent
    {
        private readonly BlogManager _blogManager;

        public DashboardLastPostsViewComponent()
        {
            _blogManager = new BlogManager(new EFBlogRepository()); ;
        }

        public IViewComponentResult Invoke()
        {
            var blogs = _blogManager.GetAllWithRelationships();
            return View(blogs);
        }
    }
}

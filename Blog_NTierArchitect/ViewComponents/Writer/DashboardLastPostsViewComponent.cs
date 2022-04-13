using BusinessLayer.Abstract;
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
        private readonly IBlogService _blogService;

        public DashboardLastPostsViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var blogs = _blogService.GetAllWithRelationships();
            return View(blogs);
        }
    }
}

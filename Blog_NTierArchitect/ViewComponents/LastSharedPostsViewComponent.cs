using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class LastSharedPostsViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public LastSharedPostsViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int count)
        {
            var blogs = _blogService.GetLastPosts(count);
            return View(blogs);
        }
    }
}

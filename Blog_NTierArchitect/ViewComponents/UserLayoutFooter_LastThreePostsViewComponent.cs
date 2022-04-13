using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class UserLayoutFooter_LastThreePostsViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public UserLayoutFooter_LastThreePostsViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var LastThreeBlogs = _blogService.GetLastPosts(3);
            return View(LastThreeBlogs);
        }
    }
}

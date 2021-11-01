using BusinessLayer.Concrete;
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
        private readonly BlogManager _blogManager;
        public UserLayoutFooter_LastThreePostsViewComponent()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
        }
        public IViewComponentResult Invoke()
        {
            var LastThreeBlogs = _blogManager.GetLastPosts(3);
            return View(LastThreeBlogs);
        }
    }
}

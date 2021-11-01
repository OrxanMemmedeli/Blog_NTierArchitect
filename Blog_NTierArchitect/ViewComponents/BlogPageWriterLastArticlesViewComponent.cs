using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class BlogPageWriterLastArticlesViewComponent : ViewComponent
    {
        private readonly BlogManager _blogManager;

        public BlogPageWriterLastArticlesViewComponent()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
        }

        public  IViewComponentResult Invoke(int? id=1)
        {
            var blogs = _blogManager.GetAllWithByWriter((int)id).OrderByDescending(c => c.CreatedDate).Take(5);
            return View(blogs);
        }
    }
}

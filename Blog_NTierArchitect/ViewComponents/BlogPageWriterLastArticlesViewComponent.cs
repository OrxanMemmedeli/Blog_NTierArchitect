using BusinessLayer.Abstract;
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
        private readonly IBlogService _blogService;

        public BlogPageWriterLastArticlesViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public  IViewComponentResult Invoke(int? id=1)
        {
            var blogs = _blogService.GetAllWithByWriter((int)id).OrderByDescending(c => c.CreatedDate).Take(5);
            return View(blogs);
        }
    }
}

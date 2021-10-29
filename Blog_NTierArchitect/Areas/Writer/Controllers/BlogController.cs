using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager;
        public BlogController()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
        }

        public IActionResult Index()
        {
            var blogsByWriter = _blogManager.GetAllWithByWriter(1);
            return View(blogsByWriter);
        }
    }
}

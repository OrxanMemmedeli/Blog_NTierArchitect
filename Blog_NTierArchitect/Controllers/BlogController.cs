using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager;
        public BlogController()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
        }

        public IActionResult Index()
        {
            var datas = _blogManager.GetAllWithRelationships();
            return View(datas);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _blogManager.GetBlogByID((int)id);
            return View(blog);
        }
    }
}

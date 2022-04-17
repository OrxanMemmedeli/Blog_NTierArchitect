using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var datas = _blogService.GetAllWithRelationships();
            return View(datas);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _blogService.GetBlogByID((int)id);
            return View(blog);
        }

    }
}

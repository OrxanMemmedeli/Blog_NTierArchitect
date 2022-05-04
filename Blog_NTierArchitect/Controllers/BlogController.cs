using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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

        public async Task<IActionResult> Index(string text, int? categoryID = 0, int? page = 1)
        {
            if (!string.IsNullOrEmpty(text) || !string.IsNullOrWhiteSpace(text))
            {
                var blogs = _blogService.GetAllWithCategoryAndComments(x => x.Status == true);
                var list = _blogService.SerachData(blogs, text);
                TempData["text"] = text;
                return View(await list.ToPagedListAsync((int)page, 9));
            }
                TempData["text"] = null;
            if (categoryID != 0)
            {
                var datas = await _blogService.GetAllWithCategoryAndComments(x => x.CategoryID == categoryID && x.Status == true).ToPagedListAsync((int)page, 9);
                return View(datas);
            }
            else
            {
                var datas = await _blogService.GetAllWithCategoryAndComments(x => x.Status == true).ToPagedListAsync((int)page, 9);
                return View(datas);
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _blogService.GetByIDWithComments((int)id);
            return View(blog);
        }

    }
}

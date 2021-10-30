using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly BlogValidator _blogValidator;
        private readonly BlogContext _context;

        public BlogController()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
            _blogValidator = new BlogValidator();
            _context = new BlogContext();
        }

        public IActionResult Index()
        {
            var blogsByWriter = _blogManager.GetAllWithByWriter(1);
            return View(blogsByWriter);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            ValidationResult results = _blogValidator.Validate(blog);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(blog);
            }
            blog.WriterID = 1;
            _blogManager.Add(blog);
            return RedirectToAction(nameof(Index));
        }
    }
}

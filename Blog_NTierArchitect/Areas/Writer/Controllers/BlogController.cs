using Blog_NTierArchitect.Customattributes;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    [CustomAuthorize("Admin, Manager, Writer, User")]

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<AppUser> _userManager;

        //private readonly BlogContext _context;

        public BlogController(IWebHostEnvironment hostEnvironment, UserManager<AppUser> userManager, IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            //_context = new BlogContext();
        }

        public IActionResult Index()
        {
            var writerID = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            var blogsByWriter = _blogService.GetAllWithRelationshipsByWriter(writerID);
            return View(blogsByWriter);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
            List<SelectListItem> items = (from x in _categoryService.GetAll()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewData["CategoryID"] = items;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (blog.ImageFile != null)
            {
                UploadImage(blog);
            }
            if (blog.ThumbnailImageFile != null)
            {
                UploadThumbnailImage(blog);
            }

            if (!ModelState.IsValid)
            {
                List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
                ViewData["CategoryID"] = categories;
                return View(blog);
            }

            blog.WriterID = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            _blogService.Add(blog);
            return RedirectToAction(nameof(Index));
        }

        private void UploadImage(Blog blog)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(blog.ImageFile.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadImages", newImageName);
            if (blog.Image != null)
            {
                System.IO.File.Delete(blog.Image);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                blog.Image = "/UploadImages/" + newImageName;
                blog.ImageFile.CopyTo(fileStream);
            }

        }
        private void UploadThumbnailImage(Blog blog)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(blog.ThumbnailImageFile.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadImages", newImageName);
            if (blog.ThumbnailImage != null)
            {
                System.IO.File.Delete(blog.ThumbnailImage);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                blog.ThumbnailImage = "/UploadImages/" + newImageName;
                blog.ThumbnailImageFile.CopyTo(fileStream);
            }

        }

        [CustomAuthorize("Admin, Manager ")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = _blogService.GetById((int)id);
            if (blog == null)
            {
                return NotFound();

            }

            if (blog.Image != null)
            {
                System.IO.File.Delete(blog.Image);
            }
            if (blog.ThumbnailImage != null)
            {
                System.IO.File.Delete(blog.ThumbnailImage);
            }

            _blogService.Delete(blog);
            TempData["DeleteBlog"] = "Blog silindi";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var blog = _blogService.GetById((int)id);
            if (blog == null)
            {
                return NotFound();

            }

            List<SelectListItem> items = (from x in _categoryService.GetAll()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewData["CategoryID"] = items;
            return View(blog);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog blog)
        {
            if (blog.ImageFile != null)
            {
                UploadImage(blog);
            }
            if (blog.ThumbnailImageFile != null)
            {
                UploadThumbnailImage(blog);
            }
            if (!ModelState.IsValid)
            {
                List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
                ViewData["CategoryID"] = categories;
                return View(blog);
            }


            _blogService.Update(blog);
            TempData["EditBlog"] = "Blog məlumatları yeniləndi.";
            return RedirectToAction(nameof(Index));
        }
    }
}

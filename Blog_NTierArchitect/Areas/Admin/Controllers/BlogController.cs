using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Manager")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IWebHostEnvironment hostEnvironment)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAllWithRelationships();
            return View(blogs);
        }
        [Authorize(Roles = "Admin")]
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
                if (System.IO.File.Exists(blog.Image))
                {
                    System.IO.File.Delete(blog.Image);
                }
            }
            if (blog.ThumbnailImage != null)
            {
                if (System.IO.File.Exists(blog.ThumbnailImage))
                {
                    System.IO.File.Delete(blog.ThumbnailImage);
                }
            }

            _blogService.Delete(blog);
            TempData["DeleteAdminBlog"] = "Blog silindi";
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
            TempData["EditAdminBlog"] = "Blog məlumatları yeniləndi.";
            return RedirectToAction(nameof(Index));
        }
    }
}

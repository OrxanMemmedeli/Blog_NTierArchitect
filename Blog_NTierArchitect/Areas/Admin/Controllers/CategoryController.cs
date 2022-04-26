using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Conrete;
using X.PagedList;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Manager")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ExcelExport<Category> _excelExport;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _excelExport = new ExcelExport<Category>();
        }

        public IActionResult Index(int page = 1)
        {
            var categories = _categoryService.GetAll().ToPagedList(page, 10);
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _categoryService.Add(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById((int)id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _categoryService.Update(category);
            TempData["EditCategory"] = "Məlumat yeniləndi.";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById((int)id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Delete(category);
            TempData["DeleteCategory"] = "Məlumat silindi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportDataToExcel()
        {
            List<Category> categories = _categoryService.GetAll();

            var content = _excelExport.ExportToExcel(categories);

            return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Cateqoriyalar-Admin.xlsx");
        }
    }
}

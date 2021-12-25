using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly CategoryValidator _validator;
        private readonly ExcelExport<Category> _excelExport;
        public CategoryController()
        {
            _categoryManager = new CategoryManager(new EFCategoryRepository());
            _validator = new CategoryValidator();
            _excelExport = new ExcelExport<Category>();
        }

        public IActionResult Index(int page = 1)
        {
            var categories = _categoryManager.GetAll().ToPagedList(page, 10);
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
            ValidationResult results = _validator.Validate(category);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(category);
            }

            _categoryManager.Add(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryManager.GetById((int)id);
            
            if (category == null)
            {
                return NotFound();
            }
            
            _categoryManager.Delete(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportDataToExcel()
        {
            List<Category> categories = _categoryManager.GetAll();

            var content =  _excelExport.ExportToExcel(categories);

            return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Cateqoriyalar-Admin.xlsx");
        }
    }
}

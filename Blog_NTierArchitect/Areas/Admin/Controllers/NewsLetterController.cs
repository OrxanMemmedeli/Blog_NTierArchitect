using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Conrete;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Manager")]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _newsLetterService;
        private readonly ExcelExport<NewsLetter> _excelExport;

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
            _excelExport = new ExcelExport<NewsLetter>();

        }

        public IActionResult Index()
        {
            var emails = _newsLetterService.GetAll();
            return View(emails);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emails = _newsLetterService.GetById((int)id);

            if (emails == null)
            {
                return NotFound();
            }

            _newsLetterService.Delete(emails);
            TempData["DeleteNewsLetter"] = "Məlumat silindi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Status(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emails = _newsLetterService.GetById((int)id);

            if (emails == null)
            {
                return NotFound();
            }

            emails.Status = !emails.Status;

            _newsLetterService.Update(emails);

            TempData["StatusNewsLetter"] = "Status dəyişdirildi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportDataToExcel()
        {
            List<NewsLetter> emails = _newsLetterService.GetAll();

            var content = _excelExport.ExportToExcel(emails);

            return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Abonə_olmuş_emaillər-Admin.xlsx");
        }
    }
}

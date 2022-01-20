using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private readonly WriterManager _writerManager;
        public WriterController()
        {
            _writerManager = new WriterManager(new EFWriterRepository());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllWriters()
        {
            var writers = _writerManager.GetAll();
            var jsonList = JsonConvert.SerializeObject(writers);
            return Json(jsonList);
        }

        public IActionResult GetWriter(int id)
        {
            var writer = _writerManager.GetById(id);
            var jsonFormat = JsonConvert.SerializeObject(writer);
            return Json(jsonFormat);
        }

        public IActionResult Create(EntityLayer.Concrete.Writer writer)
        {
            return Json(writer);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

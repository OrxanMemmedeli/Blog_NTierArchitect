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
    }
}

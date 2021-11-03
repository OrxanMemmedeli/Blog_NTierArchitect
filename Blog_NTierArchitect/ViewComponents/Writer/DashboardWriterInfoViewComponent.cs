using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents.Writer
{
    public class DashboardWriterInfoViewComponent : ViewComponent
    {
        private readonly WriterManager _WriterManager;

        public DashboardWriterInfoViewComponent()
        {
            _WriterManager = new WriterManager(new EFWriterRepository());
        }

        public IViewComponentResult Invoke()
        {
            var writers = _WriterManager.GetWritersByID(1);
            return View(writers);
        }
    }
}

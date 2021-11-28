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
        private readonly WriterManager _writerManager;

        public DashboardWriterInfoViewComponent()
        {
            _writerManager = new WriterManager(new EFWriterRepository());
        }

        public IViewComponentResult Invoke()
        {
            var writers = _writerManager.GetWritersByID(_writerManager.GetWriter(User.Identity.Name).ID);
            return View(writers);
        }
    }
}

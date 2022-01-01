using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Blog_NTierArchitect.Areas.Admin.ViewComponents.Widgets
{
    public class WidgetSecondRowViewComponent : ViewComponent
    {
        private readonly BlogManager _blogManager;
        public WidgetSecondRowViewComponent()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.LastBlog = _blogManager.GetAll().OrderByDescending(x => x.ID).Take(1).First();

            string today = DateTime.Now.ToString("dd.MM.yyyy");
            string url = "https://www.cbar.az/currencies/" + today + ".xml";
            XDocument doc = XDocument.Load(url);
            var xmlList = doc.Descendants("Valute");

            foreach (var item in xmlList)
            {
                if (item.Attribute("Code").Value == "USD")
                {
                    ViewBag.Name = item.Descendants("Name").ElementAt(0).Value;
                    ViewBag.Value = item.Descendants("Value").ElementAt(0).Value;
                    ViewBag.Date = today;
                }
            }
            return View();
        }
    }
}

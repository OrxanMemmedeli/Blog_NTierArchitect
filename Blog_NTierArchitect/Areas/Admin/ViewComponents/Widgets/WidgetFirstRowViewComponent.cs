using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog_NTierArchitect.Areas.Admin.ViewComponents.Widgets
{
    public class WidgetFirstRowViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly IContactService _contactService;
        private readonly ICommentService _commentService;

        public WidgetFirstRowViewComponent(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
            _contactService = contactService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalBlogs = _blogService.GetAll().Count();
            ViewBag.TotalContacts = _contactService.GetAll().Count();
            ViewBag.TotalComments = _commentService.GetAll().Count();

            string key = "7d0c4896cef55074b785aeecda572585";
            string city = "Baku";
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=az&units=metric&appid=" + key;
            XDocument doc = XDocument.Load(url);

            ViewBag.Temperature = doc.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.City = doc.Descendants("city").ElementAt(0).Attribute("name").Value;
            return View();
        }
    }
}

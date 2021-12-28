using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.ViewComponents.Widgets
{
    public class WidgetFirstRowViewComponent : ViewComponent
    {
        private readonly BlogManager _blogManager;
        private readonly ContactManager _contactManager;
        private readonly CommentManager _commentManager;

        public WidgetFirstRowViewComponent()
        {
            _blogManager = new BlogManager(new EFBlogRepository());
            _contactManager = new ContactManager(new EFContactRepository());
            _commentManager = new CommentManager(new EFCommentRepository());
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalBlogs = _blogManager.GetAll().Count();
            ViewBag.TotalContacts = _contactManager.GetAll().Count();
            ViewBag.TotalComments = _commentManager.GetAll().Count();
            return View();
        }
    }
}

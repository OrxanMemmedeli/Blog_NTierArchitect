using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class BlogPageCommentViewComponent : ViewComponent
    {
        private readonly CommentManager _commentManager;

        public BlogPageCommentViewComponent()
        {
            _commentManager = new CommentManager(new EFCommentRepository());

        }
        public IViewComponentResult Invoke(int id)
        {
            var comments = _commentManager.GetAll(x => x.BlogID == id);
            return View(comments);
        }
    }
}

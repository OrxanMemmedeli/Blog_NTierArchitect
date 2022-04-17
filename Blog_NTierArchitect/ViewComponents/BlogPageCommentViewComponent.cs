using BusinessLayer.Abstract;
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
        private readonly ICommentService _commentService;

        public BlogPageCommentViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var comments = _commentService.GetAll(x => x.BlogID == id && x.Status== true);
            return View(comments);
        }
    }
}

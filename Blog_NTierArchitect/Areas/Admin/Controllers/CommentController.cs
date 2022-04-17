using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var comments = _commentService.GetAllWithBlog();
            return View(comments);
        }

    }
}

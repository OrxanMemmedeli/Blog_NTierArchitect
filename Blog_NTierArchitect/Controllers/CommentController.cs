using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _commentManager;

        public CommentController()
        {
            _commentManager = new CommentManager(new EFCommentRepository());
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriteComment(int id, string Name, string Subject, string Message)
        {
            Comment comment = new Comment();
            comment.UserName = Name;
            comment.Title = Subject;
            comment.Content = Message;
            comment.BlogID = id;

            _commentManager.CommentAdd(comment);

            TempData["CommentSuccess"] = "Şərhiniz qeyde alınmışdır. Şərh üçün təşəkkür edirik.";
            return Redirect("/Blog/Details/" + id);
        }
    }
}

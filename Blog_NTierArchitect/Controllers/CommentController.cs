using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}

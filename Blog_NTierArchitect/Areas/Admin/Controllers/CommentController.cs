using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

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


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = _commentService.GetByIdWithBlog((int)id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            _commentService.Update(comment);
            TempData["EditComment"] = "Məlumat yeniləndi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = _commentService.GetById((int)id);

            if (comment == null)
            {
                return NotFound();
            }

            _commentService.Delete(comment);
            TempData["DeleteComment"] = "Məlumat silindi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = _commentService.GetById((int)id);

            if (comment == null)
            {
                return NotFound();
            }

            comment.Status = true;
            _commentService.Update(comment);
            TempData["ConfirmComment"] = "Yorum təsdiq edildi.";
            return RedirectToAction(nameof(Index));
        }
    }
}

using Blog_NTierArchitect.Models.ViewModels;
using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly CommentValidator validator;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
            validator = new CommentValidator();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WriteComment(CommentViewModel model)
        {
            Comment comment = model;

            if (!ModelState.IsValid)
            {
                TempData["CommentErrors"] = null;
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                foreach (var item in errors)
                {
                    TempData["CommentErrors"] += "*" + item + "\n";
                }
                return Redirect("/Blog/Details/" + model.BlogID);
            }
            ValidationResult result = validator.Validate(comment);
            if (!result.IsValid)
            {
                TempData["CommentErrors"] = null;
                foreach (var item in result.Errors)
                {
                    TempData["CommentErrors"] += "*" + item.ErrorMessage + "\n";
                }
                return Redirect("/Blog/Details/" + model.BlogID);
            }

            _commentService.Add(comment);

            TempData["CommentSuccess"] = "Şərhiniz qeyde alınmışdır. Şərh üçün təşəkkür edirik.";
            return Redirect("/Blog/Details/" + model.BlogID);
        }
    }
}

using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly MessageValidator _messageValidator;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _messageService = messageService;
            _messageValidator = new MessageValidator();
            _userManager = userManager;
        }

        public IActionResult Inbox()
        {
            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            var messages = _messageService.GetAllWithWriter(x => x.ReceiverID == id);
            return View(messages);
        }

        public IActionResult Sentbox()
        {
            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            var messages = _messageService.GetAllWithWriter(x => x.SenderID == id);
            return View(messages);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Id = _userManager.GetUserId(User);
            var message = _messageService.GetOneWithWriter(x => x.ID == id);
            return View(message);
        }

        public IActionResult SendMessage()
        {
            ViewData["UsersEmail"] = GetEmails();
            return View();
        }

        private List<SelectListItem> GetEmails()
        {
            return (from x in _userManager.Users.Where(x => x.Status == true)
                    select new SelectListItem
                    {
                        Text = x.Email + (x.UserName),
                        Value = x.Id.ToString()
                    }).ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Message message)
        {
            message.SenderID = Convert.ToInt32(_userManager.GetUserId(User));

            ValidationResult results = _messageValidator.Validate(message);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewData["UsersEmail"] = GetEmails();
                return View(message);
            }
            _messageService.Add(message);
            return RedirectToAction(nameof(Sentbox));
        }

        public IActionResult IsRead(int id)
        {
            var notification = _messageService.GetById(id);
            notification.Status = false;
            _messageService.Update(notification);
            return RedirectToAction(nameof(Inbox));
        }

    }
}

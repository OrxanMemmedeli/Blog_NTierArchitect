using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly MessageValidator _messageValidator;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
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

        public IActionResult SentBox()
        {
            int id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            var messages = _messageService.GetAllWithWriter(x => x.SenderID == id);
            return View(messages);
        }

        public IActionResult Common()
        {
            var messages = _messageService.GetAllWithWriter();
            return View(messages);
        }
    }
}

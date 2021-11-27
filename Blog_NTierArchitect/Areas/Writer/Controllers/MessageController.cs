using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        private readonly MessageManager _messageManager;
        private readonly MessageValidator _messageValidator;
        public MessageController()
        {
            _messageManager = new MessageManager(new EFMessageRepository());
            _messageValidator = new MessageValidator();
        }

        public IActionResult Inbox()
        {
            int id = 1;
            var messages = _messageManager.GetAllWithWriter(x => x.ReceiverID == id);
            return View(messages);
        }

        public IActionResult SentMessages()
        {
            int id = 1;
            var messages = _messageManager.GetAllWithWriter(x => x.SenderID == id);
            return View(messages);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _messageManager.GetOneWithWriter(x => x.ID == id);
            return View(message);
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents.Writer
{
    public class MessageViewComponent : ViewComponent
    {
        private readonly MessageManager _messageManager;

        public MessageViewComponent()
        {
            _messageManager = new MessageManager(new EFMessageRepository());
        }

        public IViewComponentResult Invoke()
        {
            int id = 2;
            var messages = _messageManager.GetAllWithWriter(x => x.ReceiverID == id && x.Status == true);
            ViewBag.MessageCount = messages.Count();
            return View(messages);
        }
    }
}

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
        private readonly WriterManager _writerManager;
        public MessageViewComponent()
        {
            _messageManager = new MessageManager(new EFMessageRepository());
            _writerManager = new WriterManager(new EFWriterRepository());
        }

        public IViewComponentResult Invoke()
        {
            int id = _writerManager.GetWriter(User.Identity.Name).ID;
            var messages = _messageManager.GetAllWithWriter(x => x.ReceiverID == id && x.Status == true);
            ViewBag.MessageCount = messages.Count();
            return View(messages);
        }
    }
}

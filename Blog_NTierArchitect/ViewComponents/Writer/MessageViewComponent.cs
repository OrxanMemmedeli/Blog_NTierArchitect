using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Blog_NTierArchitect.ViewComponents.Writer
{

    public class MessageViewComponent : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageViewComponent(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var id = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            var messages = _messageService.GetAllWithWriter(x => x.ReceiverID == id && x.Status == true);
            ViewBag.MessageCount = messages.Count();
            return View(messages);
        }
    }
}

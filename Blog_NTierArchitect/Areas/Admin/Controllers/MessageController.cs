using Blog_NTierArchitect.Customattributes;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CustomAuthorize("Admin, Manager")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
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

        private List<SelectListItem> GetEmails()
        {
            return (from x in _userManager.Users.Where(x => x.Status == true)
                    select new SelectListItem
                    {
                        Text = x.Email + (x.UserName),
                        Value = x.Id.ToString()
                    }).ToList();
        }

        public IActionResult SendMessage()
        {
            ViewData["AdminEmails"] = GetEmails();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Message message)
        {
            message.SenderID = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            if (ModelState.IsValid)
            {
                _messageService.Add(message);
                RedirectToAction(nameof(Index));
            }
            return View(message);
        }


        public IActionResult IsRead(int[] array)
        {
            if (array.Count() > 0)
            {
                var messages = _messageService.GetAll();
                List<Message> list = new List<Message>();
                foreach (var item in array)
                {
                    var message = messages.FirstOrDefault(x => x.ID == item);
                    if (message != null)
                    {
                        message.Status = false;
                        list.Add(message);
                    }

                }
                _messageService.UpdateRange(list);
                TempData["MessageIsRead"] = array.Count() +" mesaj oxundu olaraq qeyd edildi.";
                return Ok();
            }
            return View();
        }

        [CustomAuthorize("Admin")]
        public IActionResult Delete(int[] array)
        {
            if (array.Count() > 0)
            {
                var messages = _messageService.GetAll();
                List<Message> list = new List<Message>();
                foreach (var item in array)
                {
                    var message = messages.FirstOrDefault(x => x.ID == item);
                    if (message != null)
                    {
                        list.Add(message);
                    }
                }
                _messageService.DeleteRange(list);
                TempData["MessageIsRead"] = array.Count() + " mesaj silindi.";
                return Ok();
            }
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _messageService.GetAllWithWriter(x => x.ID == (int)id).First();

            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }
    }
}

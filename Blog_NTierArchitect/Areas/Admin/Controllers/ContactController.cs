using Blog_NTierArchitect.Customattributes;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CustomAuthorize("Admin, Manager")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public IActionResult IsRead(int[] array)
        {
            if (array.Count() > 0)
            {
                var contacts = _contactService.GetAll();
                List<Contact> list = new List<Contact>();
                foreach (var item in array)
                {
                    var message = contacts.FirstOrDefault(x => x.ID == item);
                    if (message != null)
                    {
                        message.Status = false;
                        list.Add(message);
                    }

                }
                _contactService.UpdateRange(list);
                TempData["MessageIsRead"] = array.Count() + " mesaj oxundu olaraq qeyd edildi.";
                return Ok();
            }
            return View();
        }

        [CustomAuthorize("Admin")]
        public IActionResult Delete(int[] array)
        {
            if (array.Count() > 0)
            {
                var contacts = _contactService.GetAll();
                List<Contact> list = new List<Contact>();
                foreach (var item in array)
                {
                    var message = contacts.FirstOrDefault(x => x.ID == item);
                    if (message != null)
                    {
                        list.Add(message);
                    }
                }
                _contactService.DeleteRange(list);
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

            var contact = _contactService.GetById((int)id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        private readonly NewsLetterManager _newsLetterManager;

        public NewsLetterController()
        {
            _newsLetterManager = new NewsLetterManager(new EFNewsLetterRepository());
        }

        [HttpPost]
        public IActionResult Subscribe(string Email, int? id)
        {
            NewsLetter newsLetter = new NewsLetter();
            newsLetter.Email = Email;

            _newsLetterManager.Add(newsLetter);

            TempData["SubscribeSuccess"] = "Mail adresiniz sisteme uğurla qeyd edildi. Abone olduğunuz üçün təşəkkür edirik.";
            if (id != null)
            {
                return Redirect("/Blog/Details/" + id);
            }
            return Redirect("/About");
            
        }
    }
}

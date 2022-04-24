using BusinessLayer.Abstract;
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
        private readonly INewsLetterService _newsLetterService;


        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }

        [HttpPost]
        public IActionResult Subscribe(string Email, int? id)
        {
            NewsLetter newsLetter = new NewsLetter();
            newsLetter.Email = Email;

            if (!_newsLetterService.UniqueEmailControl(Email))
            {
                _newsLetterService.Add(newsLetter);
                TempData["SubscribeSuccess"] = "Mail adresiniz sistemə uğurla qeyd edildi. Abonə olduğunuz üçün təşəkkür edirik.";
            }
            else
            {
                TempData["SubscribeSuccess"] = "Mail adresinizin abonəliyi mövcuddur. Fərqli mail ünvanı qeyd edə bilərsiniz.";
            }


            if (id != null)
            {
                return Redirect("/Blog/Details/" + id);
            }
            return Redirect("/About");

        }
    }
}

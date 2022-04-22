using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class ContactInfoViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public ContactInfoViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_aboutService.GetAll(x => x.Status == true).OrderByDescending(x => x.ID).First());
        }
    }
}

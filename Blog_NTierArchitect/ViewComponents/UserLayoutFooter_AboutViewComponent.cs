using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class UserLayoutFooter_AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public UserLayoutFooter_AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var aboutDatas = _aboutService.GetAll();
            return View(aboutDatas);
        }
    }
}

using BusinessLayer.Concrete;
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
        private readonly AboutManager _aboutManager;

        public UserLayoutFooter_AboutViewComponent()
        {
            _aboutManager = new AboutManager(new EFAboutRepository());
        }

        public IViewComponentResult Invoke()
        {
            var aboutDatas = _aboutManager.GetAll();
            return View(aboutDatas);
        }
    }
}

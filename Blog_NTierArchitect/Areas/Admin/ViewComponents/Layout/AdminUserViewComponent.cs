using Blog_NTierArchitect.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.ViewComponents.Layout
{
    public class AdminUserViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminUserViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke(string username)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == username);
            AdminUserViewModel model = new AdminUserViewModel()
            {
                UserName = user.UserName,
                ImageURL = user.ImageUrl
            };
            return View(model);
        }
    }
}

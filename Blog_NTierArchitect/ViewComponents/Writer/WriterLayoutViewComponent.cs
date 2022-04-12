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
    public class WriterLayoutViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public WriterLayoutViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //AppUser writer = Task<AppUser>.Run<AppUser>(Func<AppUser> async () => await _userManager.FindByNameAsync(username));
            AppUser writer = _userManager.Users.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            return View(writer);
        }
    }
}

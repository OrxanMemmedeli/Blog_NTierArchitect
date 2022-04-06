using Blog_NTierArchitect.Models.ViewModels;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    [AllowAnonymous]
    public class LoginUserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginUserController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (result.Succeeded)
                {
                    return Redirect("/Writer/Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Daxil olma uğursuz oldu");
                }
            }
            return View(model);
        }
    }
}

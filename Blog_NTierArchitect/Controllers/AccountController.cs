using Blog_NTierArchitect.Models;
using Blog_NTierArchitect.Models.ViewModels;
using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(ViewBag.ReturnUrl))
                {
                    return Redirect(ViewBag.ReturnUrl);
                }
                else
                {
                    return Redirect("/Writer");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserSignInViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.
                await _signInManager.SignOutAsync();
                AppUser user = _userManager.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Status == true);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return Redirect("/Writer/Dashboard");
                        }
                    }
                }
            }
            TempData["LoginMessage"] = "Uğursuz əməliyat";
            return View(model);
        }

        public IActionResult Denied()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            //HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    NameSurname = model.NameSurname,
                    Email = model.Email,
                    UserName = model.UserName
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
    }
}

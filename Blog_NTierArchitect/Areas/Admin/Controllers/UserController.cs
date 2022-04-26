using Blog_NTierArchitect.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> Profil()
        {
            EditUserViewModel user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profil(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ImageFile != null)
            {
                UploadImage(model);
            }

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            FillModel(model, user);

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                return View(model);
            }
            TempData["UpdateUserData"] = "Məlumat yeniləndi";
            return RedirectToAction(nameof(Profil));

        }

        private static void FillModel(EditUserViewModel model, AppUser user)
        {
            user.UserName = model.UserName;
            user.ImageUrl = model.Image;
            user.NameSurname = model.NameSurname;
            user.About = model.About;
            user.Email = model.Email;
            user.Status = model.Status;
        }

        public async Task<IActionResult> Edit(int id)
        {
            EditUserViewModel user = await _userManager.FindByIdAsync(id.ToString());
            ViewBag.editUserID = id;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ImageFile != null)
            {
                UploadImage(model);
            }
            AppUser user = await _userManager.FindByIdAsync(id.ToString());

            FillModel(model, user);

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                return View(model);
            }
            TempData["EditUserData"] = "Məlumat yeniləndi";
            return RedirectToAction(nameof(Index));
        }

        private void UploadImage(EditUserViewModel model)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(model.ImageFile.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadImages", newImageName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                model.Image = "/UploadImages/" + newImageName;
                model.ImageFile.CopyTo(fileStream);
            }

        }
        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(EditPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (await _userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                    return View(model);
                }
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                return Redirect("/Account/Login");
            }
            ModelState.AddModelError("", "Cari şifrə xətalıdır");
            return View(model);
        }

        public IActionResult EditPassword(int id)
        {
            ViewBag.editPasswordID = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(int id, string NewPassword)
        {
            if (NewPassword == null)
            {
                ModelState.AddModelError("", "Şifrə boş olmamalıdır.");
                return View(NewPassword);
            }

            AppUser user = await _userManager.FindByIdAsync(id.ToString());

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, NewPassword);

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["EditPassword"] = "Şifrə yeniləndi";
                await _userManager.UpdateSecurityStampAsync(user);
                return RedirectToAction(nameof(Index));
            }
            result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            return View();
        }
    }
}

using Blog_NTierArchitect.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole()
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));

            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                return NotFound();
            }
            EditRoleViewModel model = new EditRoleViewModel()
            {
                ID = role.Id,
                Name = role.Name
            };
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var role = await _roleManager.FindByIdAsync(model.ID.ToString());
            role.Name = model.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                TempData["EditRole"] = "Məlumat yeniləndi.";
                return RedirectToAction(nameof(Index));
            }
            result.Errors.ToList().ForEach(x => ModelState.AddModelError(x.Code, x.Description));
            return View(model);
        }

        public async Task<IActionResult> Delete (int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["DeleteRole"] = "Məlumat silindi.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public async Task<IActionResult> RoleAssign(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = _roleManager.Roles.ToList();

            var userRoles = await _userManager.GetRolesAsync(user);


            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();

            roles.ForEach(x => model.Add(new RoleAssignViewModel()
            {
                RoleName = x.Name,
                RoleId = x.Id,
                Exists = userRoles.Contains(x.Name)
            }));
            ViewBag.User = id;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> model, int userID) 
        {
            AppUser user = await _userManager.FindByIdAsync(userID.ToString());
            foreach (RoleAssignViewModel role in model)
            {
                if (role.Exists)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return Redirect("/Admin/User");
        }

    }
}

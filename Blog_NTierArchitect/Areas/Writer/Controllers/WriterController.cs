using Blog_NTierArchitect.Areas.Writer.Models.ViewModels;
using Blog_NTierArchitect.Areas.Writer.Models.ViewModelValidators;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Blog_NTierArchitect.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class WriterController : Controller
    {
        private readonly WriterDataUpdateValidator _validator;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<AppUser> _userManager;

        public WriterController(IWebHostEnvironment hostEnvironment, UserManager<AppUser> userManager)
        {
            _validator = new WriterDataUpdateValidator();
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Profil()
        {

            WriterDataUpdate writer = _userManager.Users.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            return View(writer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profil(WriterDataUpdate viewModel)
        {
            if (viewModel.Password == null && viewModel.ConfirmPassword == null)
            {
                viewModel.Password = viewModel.OldPassword;
                viewModel.ConfirmPassword = viewModel.OldPassword;
            }

            ValidationResult results = _validator.Validate(viewModel);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(viewModel);
            }
            if (viewModel.ImageFile != null)
            {
                UploadImage(viewModel);
            }
            
            EntityLayer.Concrete.AppUser writer = viewModel;
            _userManager.UpdateAsync(writer);
            return RedirectToAction(nameof(Profil));
        }

        private void UploadImage(WriterDataUpdate writerDataUpdate)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(writerDataUpdate.ImageFile.FileName);
            string newImageName = Guid.NewGuid() + extension;
            string path = Path.Combine(wwwRootPath, "UploadImages", newImageName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                writerDataUpdate.Image = "/UploadImages/" + newImageName;
                writerDataUpdate.ImageFile.CopyTo(fileStream);
            }

        }
    }
}

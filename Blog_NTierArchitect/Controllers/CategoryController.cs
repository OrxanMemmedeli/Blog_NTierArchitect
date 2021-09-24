﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public CategoryController()
        {
            _categoryManager = new CategoryManager(new EFCategoryRepository());
        }

        public IActionResult Index()
        {
            var datas = _categoryManager.GetAll();

            return View(datas);
        }
    }
}
﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.ViewComponents
{
    public class BlogPageMailSubscribeViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {
            TempData["SubscribeID"] = id;
            return View();
        }
    }
}

﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void CategoryAdd(Category t);
        void CategoryUpdate(Category t);
        void CategoryDelete(Category t);
        List<Category> GetAll();
        Category GetById(int id);

    }
}

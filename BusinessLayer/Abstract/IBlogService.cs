using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    interface IBlogService
    {
        void BlogAdd(Blog t);
        void BlogUpdate(Blog t);
        void BlogDelete(Blog t);
        List<Blog> GetAll();
        Blog GetById(int id);
        List<Blog> GetAllWithRelationships();

    }
}

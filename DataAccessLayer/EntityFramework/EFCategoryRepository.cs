using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework.NewFolder
{
    public class EFCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
    }
}

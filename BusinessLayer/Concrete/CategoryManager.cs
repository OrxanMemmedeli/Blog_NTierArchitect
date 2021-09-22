using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework.NewFolder;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly EFCategoryRepository _eFCategoryRepository;

        public CategoryManager(EFCategoryRepository eFCategoryRepository)
        {
            _eFCategoryRepository = eFCategoryRepository;
        }

        public void CategoryAdd(Category t)
        {
            _eFCategoryRepository.Insert(t);
        }

        public void CategoryDelete(Category t)
        {
            _eFCategoryRepository.Delete(t);
        }

        public void CategoryUpdate(Category t)
        {
            _eFCategoryRepository.Update(t);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _eFCategoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _eFCategoryRepository.GetById(id);
        }

    }
}

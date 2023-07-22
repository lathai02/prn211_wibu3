using BussinessObject.Models;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.impl
{
    public class CategoryRepository : ICategoryRepository
    {
        public void addCategory(Category category) => CategoryDao.GetCategoryDao.addCategory(category);

        public Category getCategoryWithFilms(int id)
        {
            return CategoryDao.GetCategoryDao.GetCategoryWithFilms(id);
        }

        public List<Category> getListCategoriesbyFilm(List<int> categories) => CategoryDao.GetCategoryDao.getListCategoryOfFilm(categories);
        public List<Category> getListCategory() => CategoryDao.GetCategoryDao.getListCategory();
        public void removeCategory(Category category) => CategoryDao.GetCategoryDao.removeCategory(category);
        public void updateCategory(Category category) => CategoryDao.GetCategoryDao.updateCategory(category);
        
        
    }
}

using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        List<Category> getListCategory();
        void addCategory(Category category);
        void updateCategory(Category category);
        List<Category> getListCategoriesbyFilm(List<int> categories);
        void removeCategory(Category category);
        Category getCategoryWithFilms(int id);
    }
}

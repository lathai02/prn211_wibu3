using BussinessObject.Models;
using DataAccess.Repository;
using DataAccess.Repository.impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystemWebapp.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository = new CategoryRepository();

        public CinemaSystemContext dbcontext { get; set; } = new();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            dbcontext.Dispose();
        }

        public IActionResult Index(int id)
        {
            Category category = categoryRepository.getCategoryWithFilms(id);
            return View(category);
        }
    }
}

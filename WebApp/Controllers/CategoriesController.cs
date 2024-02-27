using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View("CategoriesIndex", categories);
        }

        public IActionResult Edit(int id)
        {
            Category? category = CategoriesRepository.GetCategoryById(id);
            return View("Edit", category);
        }
    }
}

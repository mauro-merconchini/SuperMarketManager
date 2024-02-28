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

        // Does HttpGet by default when nothing is specified
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            Category? category = CategoriesRepository.GetCategoryById(id);
            return View("Edit", category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.Id, category);
                return RedirectToAction(nameof(Index));
            }
            
            return View(category);
        }

        public IActionResult Add() 
        {
            ViewBag.Action = "add";

            return View("Add"); 
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

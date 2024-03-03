using Microsoft.AspNetCore.Mvc;
using UseCases.Interfaces;
using CoreBusiness;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IDeleteCategoryUseCase deleteCategoriesUseCase;
        private readonly IEditCategoryUseCase editCategoryUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;

        public CategoriesController(
            IAddCategoryUseCase addCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoriesUseCase,
            IEditCategoryUseCase editCategoryUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase)
        {
            this.addCategoryUseCase = addCategoryUseCase;
            this.deleteCategoriesUseCase = deleteCategoriesUseCase;
            this.editCategoryUseCase = editCategoryUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
        }

        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();
            return View("CategoriesIndex", categories);
        }

        // Does HttpGet by default when nothing is specified
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            var category = viewSelectedCategoryUseCase.Execute(id);
            return View("Edit", category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                editCategoryUseCase.Execute(category.Id, category);
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
                addCategoryUseCase.Execute(category);
                return RedirectToAction(nameof(Index));
            }
            
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            deleteCategoriesUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

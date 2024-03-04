using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;
using UseCases.ProductsUseCases;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAddProductUseCase addProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;
        private readonly IViewProductsUseCase viewProductsUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;

        public ProductsController(
            IAddProductUseCase addProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IEditProductUseCase editProductUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase,
            IViewProductsUseCase viewProductsUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase)
        {
            this.addProductUseCase = addProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
            this.viewProductsUseCase = viewProductsUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
        }

        public IActionResult Index()
        {
            var products = viewProductsUseCase.Execute(loadCategory: true);
            return View("ProductsIndex", products);
        }

        // Does HttpGet by default when nothing is specified
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            ProductViewModel productViewModel = new ProductViewModel
            {
                Product = viewSelectedProductUseCase.Execute(id) ?? new Product(),
                Categories = viewCategoriesUseCase.Execute(),
            };

            return View("Edit", productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            ViewBag.Action = "edit";

            if (ModelState.IsValid)
            {
                editProductUseCase.Execute(productViewModel.Product.Id, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            ProductViewModel productViewModel = new ProductViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };

            return View("Add", productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                addProductUseCase.Execute(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = viewProductsInCategoryUseCase.Execute(categoryId);
            return PartialView("_ProductList", products);
        }
    }
}

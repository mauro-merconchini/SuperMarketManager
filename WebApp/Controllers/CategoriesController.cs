using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View("CategoriesIndex");
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Category category = new Category { Id = id.HasValue ? id.Value: 0 };
                return View("Edit", category);
            }
            
            return new ContentResult { Content = "ERROR: null or invalid id" };
        }
    }
}

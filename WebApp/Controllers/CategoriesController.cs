using Microsoft.AspNetCore.Mvc;

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
                return new ContentResult { Content = id.ToString() };
            }
            
            return new ContentResult { Content = "ERROR: null or invalid id" };
        }
    }
}

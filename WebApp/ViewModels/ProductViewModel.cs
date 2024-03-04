using CoreBusiness;

namespace WebApp.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}

using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
            
            if (salesViewModel == null)
            {
                return new ValidationResult("The sales view model is null.");
            }

            if (salesViewModel.QuantityToSell <= 0)
            {
                return new ValidationResult("The quantity to sell must be greater than zero.");
            }

            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);

            if (product == null)
            {
                return new ValidationResult("The selected product doesn't exist.");
            }

            if (product.Quantity < salesViewModel.QuantityToSell)
            {
                return new ValidationResult($"{product.Name} only has {product.Quantity} left.");
            }

            return ValidationResult.Success;
        }
    }
}

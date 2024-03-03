using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoriesInMemoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Beverage", Description = "Beverage" },
            new Category { Id = 2, Name = "Bakery", Description = "Bakery" },
            new Category { Id = 3, Name = "Meat", Description = "Meat" },
        };

        public void AddCategory(Category category)
        {
            if (_categories.Any())
            {
                var maxId = _categories.Max(c => c.Id);
                category.Id = maxId + 1;
            }
            else
            {
                category.Id = 1; // Set category ID to 1 if the list is empty
            }

            _categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            Category? category = _categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                _categories.Remove(category);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category? GetCategoryById(int categoryId)
        {
            Category? category = _categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                return new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }

            return null;
        }

        public void UpdateCategory(int categoryId, Category category)
        {
            if (category == null || category.Id != categoryId)
            {
                return;
            }

            Category? categoryToUpdate = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }
    }
}

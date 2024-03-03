﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewCategoriesUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
            return categoryRepository.GetCategories();
        }
    }
}

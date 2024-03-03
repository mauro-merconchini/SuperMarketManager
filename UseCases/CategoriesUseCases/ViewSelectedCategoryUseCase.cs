﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category? Execute(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }
    }
}

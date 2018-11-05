using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Exceptions;

namespace CookBook.Infrastructure.Repositories.Extensions
{
    public static class RecipeCategoryRepositoryExtensions
    {
        public static async Task<IEnumerable<RecipeCategory>> GetAllOrThrowAsync(this IRecipeCategoryRepository repository)
        {
            var categories = await repository.GetAllAsync();
            if (categories is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.NoRecipeCategories);
            }

            return categories;
        }

        public static async Task<RecipeCategory> GetOrThrowAsync(this IRecipeCategoryRepository repository, Guid id)
        {
            var category = await repository.GetAsync(id);
            if (category is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(id.ToString()));
            }

            return category;
        }

        public static async Task<RecipeCategory> GetOrThrowAsync(this IRecipeCategoryRepository repository, string name)
        {
            var category = await repository.GetAsync(name);
            if (category is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(name));
            }

            return category;
        }

        public static async Task AddOrThrowAsync(this IRecipeCategoryRepository repository, 
            RecipeCategoryCreateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            if (!(category is null))
            {
                throw new ServiceException(ErrorCode.CategoryExists, ErrorMessage.CategoryExists(categoryDto.Name));
            }
            category = RecipeCategory.Create(categoryDto.Name);
            await repository.AddAsync(category);
        }

        public static async Task UpdateOrThrowAsync(this IRecipeCategoryRepository repository,
            Guid id, RecipeCategoryUpdateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            if (!(category is null))
            {
                throw new ServiceException(ErrorCode.CategoryExists, ErrorMessage.CategoryExists(categoryDto.Name));
            }
            category = await repository.GetAsync(id);
            if(category is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(id.ToString()));
            }
            category.SetName(categoryDto.Name);
            await repository.UpdateAsync(category);
        }

        public static async Task RemoveOrThrowAsync(this IRecipeCategoryRepository repository, Guid categoryId)
        {
            var category = await repository.GetAsync(categoryId);
            if (category is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(categoryId.ToString()));
            }
            await repository.RemoveAsync(categoryId);
        }
    }
}
using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Repositories.Extensions
{
    public static class RecipeCategoryRepositoryExtensions
    {
        public static async Task<IEnumerable<RecipeCategory>> GetAllOrThrowAsync(this IRecipeCategoryRepository repository)
        {
            var categories = await repository.GetAllAsync();
            categories.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.NoRecipeCategories);

            return categories;
        }

        public static async Task<RecipeCategory> GetOrThrowAsync(this IRecipeCategoryRepository repository, Guid id)
        {
            var category = await repository.GetAsync(id);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(id.ToString()));

            return category;
        }

        public static async Task<RecipeCategory> GetOrThrowAsync(this IRecipeCategoryRepository repository, string name)
        {
            var category = await repository.GetAsync(name);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(name));

            return category;
        }

        public static async Task AddOrThrowAsync(this IRecipeCategoryRepository repository,
            RecipeCategoryCreateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            category.ThrowServiceExceptionIfExist(ErrorCode.CategoryExists, ErrorMessage.CategoryExists(categoryDto.Name));
            category = RecipeCategory.Create(categoryDto.Name);
            await repository.AddAsync(category);
        }

        public static async Task UpdateOrThrowAsync(this IRecipeCategoryRepository repository,
            Guid id, RecipeCategoryUpdateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            category.ThrowServiceExceptionIfExist(ErrorCode.CategoryExists, ErrorMessage.CategoryExists(categoryDto.Name));
            category = await repository.GetAsync(id);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(id.ToString()));
            category.SetName(categoryDto.Name);
            await repository.UpdateAsync(category);
        }

        public static async Task RemoveOrThrowAsync(this IRecipeCategoryRepository repository, Guid categoryId)
        {
            var category = await repository.GetAsync(categoryId);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(categoryId.ToString()));
            await repository.RemoveAsync(categoryId);
        }

        internal static void ThrowServiceExceptionIfNotExist(this RecipeCategory category, string errorCode, string errorMessage)
            => _ = category ?? throw new ServiceException(errorCode, errorMessage);

        internal static void ThrowServiceExceptionIfExist(this RecipeCategory category, string errorCode, string errorMessage)
        {
            if (!(category is null))
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }

        internal static void ThrowServiceExceptionIfNotExist(this IEnumerable<RecipeCategory> categories, string errorCode, string errorMessage)
        {
            if (categories?.Any() is false)
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }
    }
}

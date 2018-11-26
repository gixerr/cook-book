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
    public static class IngredientCategoryRepositoryExtensions
    {
        public static async Task<IEnumerable<IngredientCategory>> GetAllOrThrowAsync(this IIngredientCategoryRepository repository)
        {
            var categories = await repository.GetAllAsync();
            categories.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.NoIngredientCategories);

            return categories;
        }

        public static async Task<IngredientCategory> GetOrThrowAsync(this IIngredientCategoryRepository repository, Guid id)
        {
            var category = await repository.GetAsync(id);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(id.ToString()));

            return category;
        }

        public static async Task<IngredientCategory> GetOrThrowAsync(this IIngredientCategoryRepository repository, string name)
        {
            var category = await repository.GetAsync(name);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(name));

            return category;
        }

        public static async Task AddOrThrowAsync(this IIngredientCategoryRepository repository,
           IngredientCategoryCreateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            category.ThrowServiceExceptionIfExist(ErrorCode.CategoryExists, ErrorMessage.CategoryExists(categoryDto.Name));
            category = IngredientCategory.Create(categoryDto.Name);
            await repository.AddAsync(category);
        }

        public static async Task UpdateOrThrowAsync(this IIngredientCategoryRepository repository,
            Guid id, IngredientCategoryUpdateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            category.ThrowServiceExceptionIfExist(ErrorCode.CategoryExists, ErrorMessage.CategoryExists(categoryDto.Name));
            category = await repository.GetAsync(id);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(id.ToString()));
            category.SetName(categoryDto.Name);
            await repository.UpdateAsync(category);
        }

        public static async Task RemoveOrThrowAsync(this IIngredientCategoryRepository repository, Guid categoryId)
        {
            var category = await repository.GetAsync(categoryId);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(categoryId.ToString()));
            await repository.RemoveAsync(categoryId);
        }

        private static void ThrowServiceExceptionIfNotExist(this IngredientCategory category, string errorCode, string errorMessage)
            => _ = category ?? throw new ServiceException(errorCode, errorMessage);

        private static void ThrowServiceExceptionIfExist(this IngredientCategory category, string errorCode, string errorMessage)
        {
            if (!(category is null))
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }

        private static void ThrowServiceExceptionIfNotExist(this IEnumerable<IngredientCategory> categories, string errorCode, string errorMessage)
        {
            if (categories?.Any() is false)
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }
    }
}

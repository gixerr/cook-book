using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.DomainExtensions;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Repositories.Extensions
{
    public static class IngredientCategoryRepositoryExtensions
    {
        public static async Task<IEnumerable<IngredientCategory>> GetAllOrThrowAsync(
            this IIngredientCategoryRepository repository)
        {
            var categories = await repository.GetAllAsync();
            categories.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.NoIngredientCategories);

            return categories;
        }

        public static async Task<IngredientCategory> GetOrThrowAsync(this IIngredientCategoryRepository repository,
            Guid id)
        {
            var category = await repository.GetAsync(id);
            category.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(id.ToString()));

            return category;
        }

        public static async Task<IngredientCategory> GetOrThrowAsync(this IIngredientCategoryRepository repository,
            string name)
        {
            var category = await repository.GetAsync(name);
            category.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(name));

            return category;
        }

        public static async Task AddOrThrowAsync(this IIngredientCategoryRepository repository,
            IngredientCategoryCreateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            category.ThrowServiceExceptionIfExist(ErrorCode.CategoryExists,
                ErrorMessage.CategoryExists(categoryDto.Name));
            category = IngredientCategory.Create(categoryDto.Name);
            await repository.AddAsync(category);
        }

        public static async Task UpdateOrThrowAsync(this IIngredientCategoryRepository repository,
            IngredientCategoryUpdateDto categoryDto)
        {
            var category = await repository.GetAsync(categoryDto.Name);
            category.ThrowServiceExceptionIfExist(ErrorCode.CategoryExists,
                ErrorMessage.CategoryExists(categoryDto.Name));
            category = await repository.GetOrThrowAsync(categoryDto.Id);
            category.SetName(categoryDto.Name);
            await repository.UpdateAsync(category);
        }

        public static async Task RemoveOrThrowAsync(this IIngredientCategoryRepository repository, Guid categoryId)
        {
            var category = await repository.GetOrThrowAsync(categoryId);
            await repository.RemoveAsync(category);
        }
    }
}

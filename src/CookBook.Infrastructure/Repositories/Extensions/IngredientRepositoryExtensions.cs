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
    //TODO: Change to GetOrThrowAsync
    public static class IngredientRepositoryExtensions
    {
        public static async Task<IEnumerable<Ingredient>> GetAllOrThrowAsync(this IIngredientRepository repository)
        {
            var ingredients = await repository.GetAllAsync();
            ingredients.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.NoIngredients);

            return ingredients;
        }

        public static async Task<IEnumerable<Ingredient>> GetOrThrowAsync(this IIngredientRepository repository,
            string name)
        {
            var ingredients = await repository.GetAsync(name);
            ingredients.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.IngredientNotFound(name));

            return ingredients;
        }

        public static async Task<Ingredient> GetOrThrowAsync(this IIngredientRepository repository, Guid id)
        {
            var ingredient = await repository.GetAsync(id);
            ingredient.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound,
                ErrorMessage.IngredientNotFound(id.ToString()));

            return ingredient;
        }

        public static async Task<IEnumerable<Ingredient>> GetOrThrowAsync(this IIngredientRepository repository,
            IngredientCategory ingredientCategory)
        {
            var ingredients = await repository.GetAsync(ingredientCategory);
            ingredients.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound,
                ErrorMessage.RecipeWithCategoryNotFound(ingredientCategory.Name));

            return ingredients;
        }

        public static async Task AddOrThrowAsync(this IIngredientRepository ingredientRepository,
            IIngredientCategoryRepository ingredientCategoryRepository,
            IngredientCreateDto ingredientDto)
        {
            var category = await ingredientCategoryRepository.GetAsync(ingredientDto.CategoryName);
            category.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound,
                ErrorMessage.CategoryNotFound(ingredientDto.CategoryName));
            var ingredients = await ingredientRepository.GetAsync(ingredientDto.Name);
            ingredients.ThrowServiceExceptionIfExist(ingredientDto.Name, ErrorCode.IngredientExists,
                ErrorMessage.IngredientExists(ingredientDto.Name));
            var ingredient = Ingredient.Create(ingredientDto.Name, category);
            await ingredientRepository.AddAsync(ingredient);
        }

        public static async Task UpdateOrThrowAsync(this IIngredientRepository ingredientRepository,
            IIngredientCategoryRepository ingredientCategoryRepository,
            IngredientUpdateDto ingredientDto)
        {
            var category = await ingredientCategoryRepository.GetAsync(ingredientDto.CategoryName);
            category.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound,
                ErrorMessage.CategoryNotFound(ingredientDto.CategoryName));
            var ingredients = await ingredientRepository.GetAsync(ingredientDto.Name);
            ingredients.ThrowServiceExceptionIfExist(ingredientDto.Name, ErrorCode.IngredientExists,
                ErrorMessage.IngredientExists(ingredientDto.Name));
            var ingredient = await ingredientRepository.GetOrThrowAsync(ingredientDto.Id);
            ingredient.SetName(ingredientDto.Name);
            ingredient.SetCategory(category);
            await ingredientRepository.UpdateAsync(ingredient);
        }

        public static async Task RemoveOrThrowAsync(this IIngredientRepository repository, Guid id)
        {
            var ingredient = await repository.GetOrThrowAsync(id);
            ingredient.ThrowInfrastructureExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(id.ToString()));
            await repository.RemoveAsync(ingredient);
        }
    }
}

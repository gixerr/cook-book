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
    public static class IngredientRepositoryExtensions
    {
        public static async Task<IEnumerable<Ingredient>> GetAllOrThrowAsync(this IIngredientRepository repository)
        {
            var ingredients = await repository.GetAllAsync();
            if (ingredients?.Any() is false)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.NoIngredients);
            }

            return ingredients;
        }

        public static async Task<IEnumerable<Ingredient>> GetOrThrowAsync(this IIngredientRepository repository, string name)
        {
            var ingredients = await repository.GetAsync(name);
            if (ingredients?.Any() is false)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.IngredientNotFound(name));
            }

            return ingredients;
        }

        public static async Task<Ingredient> GetOrThrowAsync(this IIngredientRepository repository, Guid id)
        {
            var ingredient = await repository.GetAsync(id);
            if (ingredient is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.IngredientNotFound(id.ToString()));
            }

            return ingredient;
        }

        public static async Task<IEnumerable<Ingredient>> GetOrThrowAsync(this IIngredientRepository repository, IngredientCategory ingredientCategory)
        {
            var ingredients = await repository.GetAsync(ingredientCategory);
            if (ingredients?.Any() is false)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.RecipeWithCategoryNotFound(ingredientCategory.Name));
            }

            return ingredients;
        }

        public static async Task AddOrThrowAsync(this IIngredientRepository ingredientRepository, IIngredientCategoryRepository ingredientCategoryRepository,
            IngredientCreateDto ingredientDto)
        {
            var category = await ingredientCategoryRepository.GetAsync(ingredientDto.CategoryName);
            if (category is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(ingredientDto.CategoryName));
            }
            var ingredients = await ingredientRepository.GetAsync(ingredientDto.Name);
            if (ingredients?.Any(x => x.Category.Name.Equals(ingredientDto.CategoryName, StringComparison.InvariantCultureIgnoreCase)) is true)
            {
                throw new ServiceException(ErrorCode.IngredientExists, ErrorMessage.IngredientExists(ingredientDto.Name));
            }
            var ingredient = Ingredient.Create(ingredientDto.Name, category);
            await ingredientRepository.AddAsync(ingredient);
        }

        public static async Task UpdateOrThrowAsync(this IIngredientRepository ingredientRepository, IIngredientCategoryRepository ingredientCategoryRepository,
            Guid id, IngredientUpdateDto ingredientDto)
        {
            var category = await ingredientCategoryRepository.GetAsync(ingredientDto.CategoryName);
            if (category is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(ingredientDto.CategoryName));
            }
            var ingredients = await ingredientRepository.GetAsync(ingredientDto.Name);
            if (ingredients?.Any(x => x.Category.Name.Equals(ingredientDto.CategoryName, StringComparison.InvariantCultureIgnoreCase)) is true)
            {
                throw new ServiceException(ErrorCode.IngredientExists, ErrorMessage.IngredientExists(ingredientDto.Name));
            }
            var ingredient = await ingredientRepository.GetOrThrowAsync(id);
            ingredient.SetName(ingredientDto.Name);
            ingredient.SetCategory(category);
            await ingredientRepository.UpdateAsync(id);
        }

        public static async Task RemoveOrThrowAsync(this IIngredientRepository repository, Guid id)
        {
            var ingredient = await repository.GetOrThrowAsync(id);
            if (ingredient is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(id.ToString()));
            }
            await repository.RemoveAsync(id);
        }
    }
}

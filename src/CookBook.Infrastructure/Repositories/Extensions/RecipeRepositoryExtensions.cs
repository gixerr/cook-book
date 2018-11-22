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
    public static class RecipeRepositoryExtensions
    {
        public static async Task<IEnumerable<Recipe>> GetAllOrThrowAsync(this IRecipeRepository repository)
        {
            var recipes = await repository.GetAllAsync();
            if (recipes is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.NoRecipes);
            }

            return recipes;
        }

        public static async Task<Recipe> GetOrThrowAsync(this IRecipeRepository repository, Guid id)
        {
            var recipe = await repository.GetAsync(id);
            if (recipe is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(id.ToString()));
            }

            return recipe;
        }

        public static async Task<IEnumerable<Recipe>> GetOrThrowAsync(this IRecipeRepository repository, string name)
        {
            var recipes = await repository.GetAsync(name);
            if (recipes is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(name));
            }

            return recipes;
        }

        public static async Task<IEnumerable<Recipe>> GetOrThrowAsync(this IRecipeRepository repository, RecipeCategory recipeCategory)
        {
            var recipes = await repository.GetAsync(recipeCategory);
            if (recipes is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.RecipeWithCategoryNotFound(recipeCategory.Name));
            }

            return recipes;
        }

        public static async Task AddOrThrowAsync(this IRecipeRepository recipeRepository, IRecipeCategoryRepository recipeCategoryRepository,
            RecipeCreateDto recipeDto)
        {
            var recipeCategory = await recipeCategoryRepository.GetAsync(recipeDto.CategoryName);
            if (recipeCategory is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(recipeDto.CategoryName));
            }
            var recipes = await recipeRepository.GetAsync(recipeDto.Name);
            if (recipes?.Any(x => x.Category.Name.Equals(recipeDto.CategoryName, StringComparison.InvariantCultureIgnoreCase)) is true)
            {
                throw new ServiceException(ErrorCode.RecipeExists, ErrorMessage.RecipeExists(recipeDto.Name));
            }
            var recipe = Recipe.Create(recipeDto.Name, recipeCategory, recipeDto.ShortDescription, recipeDto.Preparation);
            await recipeRepository.AddAsync(recipe);
        }

        public static async Task UpdateOrThrowAsync(this IRecipeRepository repository, IRecipeCategoryRepository recipeCategoryRepository,
            Guid id, RecipeUpdateDto recipeDto)
        {
            var recipeCategory = await recipeCategoryRepository.GetAsync(recipeDto.CategoryName);
            if (recipeCategory is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.CategoryNotFound(recipeDto.CategoryName));
            }
            var recipes = await repository.GetAsync(recipeDto.Name);
            if (recipes?.Any(x => x.Category.Name.Equals(recipeDto.CategoryName, StringComparison.InvariantCultureIgnoreCase)) is true)
            {
                throw new ServiceException(ErrorCode.RecipeExists, ErrorMessage.RecipeExists(recipeDto.Name));
            }
            var recipe = await repository.GetOrThrowAsync(id);
            recipe.SetName(recipeDto.Name);
            recipe.SetCategory(recipeCategory);
            recipe.SetShortDescription(recipeDto.ShortDescription);
            recipe.SetPreparation(recipeDto.Preparation);
            await repository.UpdateAsync(id);
        }

        public static async Task RemoveOrThrowAsync(this IRecipeRepository repository, Guid id)
        {
            var recipe = await repository.GetOrThrowAsync(id);
            if (recipe is null)
            {
                throw new ServiceException(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(id.ToString()));
            }
            await repository.RemoveAsync(id);
        }
    }
}

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
    public static class RecipeRepositoryExtensions
    {
        //TODO: Change to GetOrThrowAsync
        public static async Task<IEnumerable<Recipe>> GetAllOrThrowAsync(this IRecipeRepository repository)
        {
            var recipes = await repository.GetAllAsync();
            recipes.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.NoRecipes);

            return recipes;
        }

        public static async Task<Recipe> GetOrThrowAsync(this IRecipeRepository repository, Guid id)
        {
            var recipe = await repository.GetAsync(id);
            recipe.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(id.ToString()));

            return recipe;
        }

        public static async Task<IEnumerable<Recipe>> GetOrThrowAsync(this IRecipeRepository repository, string name)
        {
            var recipes = await repository.GetAsync(name);
            recipes.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(name));

            return recipes;
        }

        public static async Task<IEnumerable<Recipe>> GetOrThrowAsync(this IRecipeRepository repository,
            RecipeCategory recipeCategory)
        {
            var recipes = await repository.GetAsync(recipeCategory);
            recipes.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound,
                ErrorMessage.RecipeWithCategoryNotFound(recipeCategory.Name));

            return recipes;
        }

        public static async Task AddOrThrowAsync(this IRecipeRepository recipeRepository,
            IRecipeCategoryRepository recipeCategoryRepository,
            RecipeCreateDto recipeDto)
        {
            var category = await recipeCategoryRepository.GetAsync(recipeDto.CategoryName);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound,
                ErrorMessage.CategoryNotFound(recipeDto.CategoryName));
            var recipes = await recipeRepository.GetAsync(recipeDto.Name);
            recipes.ThrowServiceExceptionIfExist(recipeDto.CategoryName, ErrorCode.RecipeExists,
                ErrorMessage.RecipeExists(recipeDto.Name));
            var recipe = Recipe.Create(recipeDto.Name, category, recipeDto.ShortDescription, recipeDto.Preparation);
            await recipeRepository.AddAsync(recipe);
        }

        public static async Task UpdateOrThrowAsync(this IRecipeRepository repository,
            IRecipeCategoryRepository recipeCategoryRepository,
            RecipeUpdateDto recipeDto)
        {
            var category = await recipeCategoryRepository.GetAsync(recipeDto.CategoryName);
            category.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound,
                ErrorMessage.CategoryNotFound(recipeDto.CategoryName));
            var recipe = await repository.GetOrThrowAsync(recipeDto.Id);
            recipe.SetName(recipeDto.Name);
            recipe.SetCategory(category);
            recipe.SetShortDescription(recipeDto.ShortDescription);
            recipe.SetPreparation(recipeDto.Preparation);
            await repository.UpdateAsync(recipeDto.Id);
        }

        public static async Task RemoveOrThrowAsync(this IRecipeRepository repository, Guid id)
        {
            var recipe = await repository.GetOrThrowAsync(id);
            recipe.ThrowServiceExceptionIfNotExist(ErrorCode.NotFound, ErrorMessage.RecipeNotFound(id.ToString()));
            await repository.RemoveAsync(id);
        }
    }
}

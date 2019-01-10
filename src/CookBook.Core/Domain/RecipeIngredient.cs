using System;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; protected set; }
        public Guid IngredientId { get; protected set; }
        public string Name { get; protected set; }
        public IngredientCategory Category { get; protected set; }
        public string Measure { get; protected set; }
        public float Amount { get; protected set; }

        protected RecipeIngredient()
        {
        }

        private RecipeIngredient(Guid recipeId, Guid ingredientId, string name, IngredientCategory category,
            string measure, float amount)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
            SetName(name);
            SetCategory(category);
            SetMeasure(measure);
            SetAmount(amount);
        }

        public static RecipeIngredient Create(Guid recipeId, Ingredient ingredient, string measure, float amount)
            => new RecipeIngredient(recipeId, ingredient.Id, ingredient.Name, ingredient.Category, measure, amount);

        private void SetName(string name)
            => Name = name ?? throw new CoreException(ErrorCode.EmptyModelProperty,
                          ErrorMessage.EmptyRecipeIngredientName);

        private void SetCategory(IngredientCategory category)
            => Category = category ?? throw new CoreException(ErrorCode.EmptyModelProperty,
                              ErrorMessage.EmptyRecipeIngredientCategory);

        private void SetMeasure(string measure)
            => Measure = measure ?? throw new CoreException(ErrorCode.EmptyModelProperty,
                             ErrorMessage.EmptyRecipeIngredientMeasure);

        private void SetAmount(float amount) => Amount = amount <= 0
                                                            ? throw new CoreException(ErrorCode.EmptyModelProperty,
                                                                  ErrorMessage.InvalidRecipeIngredientAmount)
                                                            : amount;

        public void IncreaseAmount(float amount)
            => Amount += amount;
    }
}

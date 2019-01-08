using System;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    public class RecipeIngredient : Entity
    {
        public string Name { get; protected set; }
        public IngredientCategory Category { get; protected set; }
        public string Measure { get; protected set; }
        public float Amount { get; protected set; }

        protected RecipeIngredient()
        {
        }

        private RecipeIngredient(Guid id, string name, IngredientCategory category, string measure, float amount)
        {
            Id = id;
            SetName(name);
            SetCategory(category);
            SetMeasure(measure);
            SetAmount(amount);
        }

        public static RecipeIngredient Create(Ingredient ingredient, string measure, float amount)
            => new RecipeIngredient(ingredient.Id, ingredient.Name, ingredient.Category, measure, amount);
        
        public void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipeIngredientName);
        
        public void SetCategory(IngredientCategory category)
            => Category = Validate(category, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipeIngredientCategory);

        public void SetMeasure(string measure)
            => Measure = Validate(measure, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipeIngredientMeasure);

        public void SetAmount(float amount)
        {
            if (amount <= 0)
            {
                throw new CoreException(ErrorCode.EmptyModelProperty, ErrorMessage.InvalidRecipeIngredientAmount);
            }
            Amount = amount;
        }

        public void IncreaseAmount(float amount)
            => Amount += amount;
    }
}
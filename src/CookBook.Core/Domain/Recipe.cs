using System.Collections.Generic;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    public class Recipe : Entity
    {
        private ISet<RecipeIngredient> _ingredients = new HashSet<RecipeIngredient>();
        public string Name { get; protected set; }
        public RecipeCategory Category { get; protected set; }
        public IEnumerable<RecipeIngredient> Ingredients => _ingredients;
        public string ShortDescription { get; protected set; }
        public string Preparation { get; protected set; }

        private Recipe(string name, RecipeCategory category, IEnumerable<RecipeIngredient> ingredients, string preparation)
            : this(name, category, preparation)
        {
            SetIngredients(ingredients);
        }

        private Recipe(string name, RecipeCategory category, string preparation)
        {
            SetName(name);
            SetCategory(category);
            SetPreparation(preparation);
        }

        public static Recipe Create(string name, RecipeCategory category, IEnumerable<RecipeIngredient> ingredients, string preparation)
            => new Recipe(name, category, ingredients, preparation);

        public static Recipe CreateWithoutIngredients(string name, RecipeCategory category, string preparation)
            => new Recipe(name, category, preparation);

        public void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipeName);

        public void SetCategory(RecipeCategory category)
            => Category = Validate(category, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipeCategory);

        public void SetIngredients(IEnumerable<RecipeIngredient> ingredients)
            => _ingredients = (HashSet<RecipeIngredient>) Validate(ingredients, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyIngredientList);

        public void SetPreparation(string preparation)
            => Preparation = Validate(preparation, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipePreparation);

        public void AddIngredient(RecipeIngredient ingredient)
            => _ingredients.Add(ingredient);

        public void RemoveIngredient(RecipeIngredient ingredient)
            => _ingredients.Remove(ingredient);

        public void ClearIngredients()
            => _ingredients.Clear();
    }
}
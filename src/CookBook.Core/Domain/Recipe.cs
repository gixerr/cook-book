using System;
using CookBook.Core.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CookBook.Core.Domain
{
    [Table("Recipes")]
    public class Recipe : Entity
    {
        private ISet<RecipeIngredient> _ingredients = new HashSet<RecipeIngredient>();

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public RecipeCategory Category { get; protected set; }

        public IEnumerable<RecipeIngredient> Ingredients => _ingredients;
        public string ShortDescription { get; protected set; }
        public string Preparation { get; protected set; }

        protected Recipe()
        {
        }

        private Recipe(string name, RecipeCategory category, string shortDescription, string preparation)
        {
            SetName(name);
            SetCategory(category);
            SetShortDescription(shortDescription);
            SetPreparation(preparation);
        }

        public static Recipe Create(string name, RecipeCategory category, string shortDescription, string preparation)
            => new Recipe(name, category, shortDescription, preparation);

        public void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipeName);

        public void SetCategory(RecipeCategory category)
            => Category = Validate(category, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipeCategory);

        public void SetIngredients(IEnumerable<RecipeIngredient> ingredients)
            => _ingredients = (HashSet<RecipeIngredient>)Validate(ingredients, ErrorCode.EmptyModelProperty,
                   ErrorMessage.EmptyIngredientList);

        public void SetShortDescription(string shortDescription)
            => ShortDescription = Validate(shortDescription, ErrorCode.EmptyModelProperty,
                   ErrorMessage.EmptyShortDescription);

        public void SetPreparation(string preparation)
            => Preparation = Validate(preparation, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyRecipePreparation);

        public RecipeIngredient GetIngredient(Guid id)
            => _ingredients.SingleOrDefault(x => x.IngredientId.Equals(id));

        public void AddIngredient(RecipeIngredient ingredient)
            => _ingredients.Add(ingredient);

        public void RemoveIngredient(RecipeIngredient ingredient)
            => _ingredients.Remove(ingredient);

        public void ClearIngredients()
            => _ingredients.Clear();
    }
}

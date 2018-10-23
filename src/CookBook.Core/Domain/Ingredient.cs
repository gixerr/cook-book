using System;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    public class Ingredient : Entity
    {
        public string Name { get; protected set; }
        public IngredientCategory Category { get; protected set; }

        protected Ingredient()
        {
        }

        private Ingredient(string name, IngredientCategory category)
        {
            SetName(name);
            SetCategory(category);
        }

        private void SetCategory(IngredientCategory category)
            => Category = Validate(category, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyIngredientCategory);
        private void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyIngredientName);
    }
}
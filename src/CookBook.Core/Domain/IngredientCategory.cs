using System.Collections.Generic;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    public class IngredientCategory : Entity
    {
        public string Name { get; protected set; }

        protected IngredientCategory()
        {
        }

        private IngredientCategory(string name)
        {
            SetName(name);
        }

        private void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyIngredientCategoryName);

        public static IngredientCategory Create(string name)
            => new IngredientCategory(name); 
    }
}
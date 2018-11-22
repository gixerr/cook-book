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

        public static Ingredient Create(string name, IngredientCategory category)
            => new Ingredient(name, category);

        public void SetCategory(IngredientCategory category)
            => Category = Validate(category, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyIngredientCategory);
        
        public void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyIngredientName);
    }
}
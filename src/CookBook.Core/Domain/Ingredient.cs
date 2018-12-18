using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    [Table("Ingredients")]
    public class Ingredient : Entity
    {
        [Required]
        [StringLength(255)]
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

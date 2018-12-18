using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    [Table("IngredientCategories")]
    public class IngredientCategory : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; protected set; }

        protected IngredientCategory()
        {
        }

        private IngredientCategory(string name)
        {
            SetName(name);
        }

        public static IngredientCategory Create(string name)
            => new IngredientCategory(name);

        public void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyIngredientCategoryName);
    }
}

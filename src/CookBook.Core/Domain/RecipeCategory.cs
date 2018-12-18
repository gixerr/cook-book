using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CookBook.Core.Exceptions;

namespace CookBook.Core.Domain
{
    [Table("RecipeCategories")]
    public class RecipeCategory : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }

        protected RecipeCategory()
        {
        }

        private RecipeCategory(string name)
        {
            SetName(name);
        }

        public static RecipeCategory Create(string name)
            => new RecipeCategory(name);

        public void SetName(string name)
            => Name = Validate(name, ErrorCode.EmptyModelProperty, ErrorMessage.EmptyCategoryName);
    }
}

using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class IngredientCategoryUpdateDto : ICommand
    {
        public string Name { get; set; }
    }
}

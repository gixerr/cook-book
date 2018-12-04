using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class IngredientCategoryCreateDto : ICommand
    {
        public string Name { get; set; }
    }
}

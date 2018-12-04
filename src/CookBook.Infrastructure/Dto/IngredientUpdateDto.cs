using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class IngredientUpdateDto : ICommand
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}

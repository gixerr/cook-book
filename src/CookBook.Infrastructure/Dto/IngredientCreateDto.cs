using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class IngredientCreateDto : ICommand

    {
    public string Name { get; set; }
    public string CategoryName { get; set; }
    }
}

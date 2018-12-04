using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeCategoryUpdateDto : ICommand
    {
        public string Name { get; set; }
    }
}

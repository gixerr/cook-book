using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeCategoryCreateDto : ICommand
    {
        public string Name { get; set; }
    }
}

using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeCreateDto : ICommand
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string ShortDescription { get; set; }
        public string Preparation { get; set; }
    }
}

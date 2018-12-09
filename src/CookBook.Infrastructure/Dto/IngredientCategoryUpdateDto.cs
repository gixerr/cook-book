using System;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class IngredientCategoryUpdateDto : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

using System;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class IngredientCategoryRemoveDto : ICommand
    {
        public Guid Id { get; set; }
    }
}

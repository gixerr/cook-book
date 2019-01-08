using System;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeIngredientRemoveDto : ICommand
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
    }
}

using System;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeIngredientAddDto : ICommand
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string Measure { get; set; }
        public float Amount { get; set; }

    }
}
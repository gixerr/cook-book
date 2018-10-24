using System;
using CookBook.Core.Domain;

namespace CookBook.Infrastructure.Dto
{
    public class IngredientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IngredientCategory Category { get; set; }
    }
}
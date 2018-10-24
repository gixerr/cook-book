using System;
using System.Collections.Generic;
using CookBook.Core.Domain;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public RecipeCategory Category { get; set; }
        public IEnumerable<RecipeIngredient> Ingredients { get; set; }
        public string ShortDescription { get; set; }
    }
}
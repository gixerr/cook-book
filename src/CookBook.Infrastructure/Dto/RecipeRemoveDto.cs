using System;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeRemoveDto : ICommand
    {
        public Guid Id { get; set; }
    }
}

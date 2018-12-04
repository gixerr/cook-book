using System;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Dto
{
    public class RecipeCategoryRemoveDto : ICommand
    {
        public Guid Id { get; set; }
    }
}

using CookBook.Core.Domain;
using CookBook.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Infrastructure.DomainExtensions
{
    internal static class RecipeExtensions
    {
        internal static void ThrowInfrastructureExceptionIfNotExist(this Recipe recipes, string errorCode, string errorMessage)
            => _ = recipes ?? throw new InfrastructureException(errorCode, errorMessage);

        internal static void ThrowInfrastructureExceptionIfNotExist(this IEnumerable<Recipe> recipes, string errorCode, string errorMessage)
        {
            if (recipes?.Any() is false)
            {
                throw new InfrastructureException(errorCode, errorMessage);
            }
        }

        internal static void ThrowInfrastructureExceptionIfExist(this IEnumerable<Recipe> recipes, string categoryName, string errorCode, string errorMessage)
        {
            if (recipes?.Any(x => x.Category.Name.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase)) is true)
            {
                throw new InfrastructureException(errorCode, errorMessage);
            }
        }
    }
}

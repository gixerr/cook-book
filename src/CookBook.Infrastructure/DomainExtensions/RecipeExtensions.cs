using CookBook.Core.Domain;
using CookBook.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Infrastructure.DomainExtensions
{
    internal static class RecipeExtensions
    {
        internal static void ThrowServiceExceptionIfNotExist(this Recipe recipes, string errorCode, string errorMessage)
            => _ = recipes ?? throw new ServiceException(errorCode, errorMessage);

        internal static void ThrowServiceExceptionIfNotExist(this IEnumerable<Recipe> recipes, string errorCode, string errorMessage)
        {
            if (recipes?.Any() is false)
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }

        internal static void ThrowServiceExceptionIfExist(this IEnumerable<Recipe> recipes, string categoryName, string errorCode, string errorMessage)
        {
            if (recipes?.Any(x => x.Category.Name.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase)) is true)
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }
    }
}

using CookBook.Core.Domain;
using CookBook.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Infrastructure.DomainExtensions
{
    internal static class IngredientExtensions
    {
        internal static void ThrowInfrastructureExceptionIfNotExist(this Ingredient ingredient, string errorCode, string errorMessage)
            => _ = ingredient ?? throw new InfrastructureException(errorCode, errorMessage);

        internal static void ThrowInfrastructureExceptionIfNotExist(this IEnumerable<Ingredient> ingredients, string errorCode, string errorMessage)
        {
            if (ingredients?.Any() is false)
            {
                throw new InfrastructureException(errorCode, errorMessage);
            }
        }

        internal static void ThrowServiceExceptionIfExist(this IEnumerable<Ingredient> ingredients, string categoryName, string errorCode, string errorMessage)
        {
            if (ingredients?.Any(x => x.Category.Name.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase)) is true)
            {
                throw new InfrastructureException(errorCode, errorMessage);
            }
        }
    }
}

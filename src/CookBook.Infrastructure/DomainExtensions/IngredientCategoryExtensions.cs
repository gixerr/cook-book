using CookBook.Core.Domain;
using CookBook.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Infrastructure.DomainExtensions
{
    internal static class IngredientCategoryExtensions
    {
        internal static void ThrowInfrastructureExceptionIfNotExist(this IngredientCategory category, string errorCode, string errorMessage)
            => _ = category ?? throw new InfrastructureException(errorCode, errorMessage);

        internal static void ThrowServiceExceptionIfExist(this IngredientCategory category, string errorCode, string errorMessage)
        {
            if (!(category is null))
            {
                throw new InfrastructureException(errorCode, errorMessage);
            }
        }

        internal static void ThrowInfrastructureExceptionIfNotExist(this IEnumerable<IngredientCategory> categories, string errorCode, string errorMessage)
        {
            if (categories?.Any() is false)
            {
                throw new InfrastructureException(errorCode, errorMessage);
            }
        }
    }
}

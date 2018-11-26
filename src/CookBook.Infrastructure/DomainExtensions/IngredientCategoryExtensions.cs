using CookBook.Core.Domain;
using CookBook.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Infrastructure.DomainExtensions
{
    internal static class IngredientCategoryExtensions
    {
        internal static void ThrowServiceExceptionIfNotExist(this IngredientCategory category, string errorCode, string errorMessage)
            => _ = category ?? throw new ServiceException(errorCode, errorMessage);

        internal static void ThrowServiceExceptionIfExist(this IngredientCategory category, string errorCode, string errorMessage)
        {
            if (!(category is null))
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }

        internal static void ThrowServiceExceptionIfNotExist(this IEnumerable<IngredientCategory> categories, string errorCode, string errorMessage)
        {
            if (categories?.Any() is false)
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }
    }
}

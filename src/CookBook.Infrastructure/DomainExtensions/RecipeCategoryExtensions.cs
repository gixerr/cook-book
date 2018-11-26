using CookBook.Core.Domain;
using CookBook.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Infrastructure.DomainExtensions
{
    internal static class RecipeCategoryExtensions
    {
        internal static void ThrowServiceExceptionIfNotExist(this RecipeCategory category, string errorCode, string errorMessage)
            => _ = category ?? throw new ServiceException(errorCode, errorMessage);

        internal static void ThrowServiceExceptionIfExist(this RecipeCategory category, string errorCode, string errorMessage)
        {
            if (!(category is null))
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }

        internal static void ThrowServiceExceptionIfNotExist(this IEnumerable<RecipeCategory> categories, string errorCode, string errorMessage)
        {
            if (categories?.Any() is false)
            {
                throw new ServiceException(errorCode, errorMessage);
            }
        }
    }
}

using CookBook.Core.Domain;
using CookBook.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CookBook.Infrastructure.DomainExtensions
{
    internal static class RecipeCategoryExtensions
    {
        internal static void ThrowInfrastructureExceptionIfNotExist(this RecipeCategory category, string errorCode, string errorMessage)
            => _ = category ?? throw new InfrastructureException(errorCode, errorMessage, HttpStatusCode.NotFound);

        internal static void ThrowInfrastructureExceptionIfExist(this RecipeCategory category, string errorCode, string errorMessage)
        {
            if (!(category is null))
            {
                throw new InfrastructureException(errorCode, errorMessage, HttpStatusCode.Conflict );
            }
        }

        internal static void ThrowInfrastructureExceptionIfNotExist(this IEnumerable<RecipeCategory> categories, string errorCode, string errorMessage)
        {
            if (categories?.Any() is false)
            {
                throw new InfrastructureException(errorCode, errorMessage, HttpStatusCode.NotFound);
            }
        }
    }
}

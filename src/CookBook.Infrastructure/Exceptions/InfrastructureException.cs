using CookBook.Core.Exceptions;

namespace CookBook.Infrastructure.Exceptions
{
    public class InfrastructureException : BaseAppException
    {
        public InfrastructureException(string errorCode, string errorMessage)
            : base(errorCode, errorMessage)
        {
        }
    }
}

using CookBook.Core.Exceptions;

namespace CookBook.Infrastructure.Exceptions
{
    public class ServiceException : BaseAppException
    {
        public ServiceException(string errorCode, string erroeMessage)
            : base(errorCode, erroeMessage)
        {
        }
    }
}
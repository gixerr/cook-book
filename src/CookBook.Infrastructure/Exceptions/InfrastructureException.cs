using System.Net;
using CookBook.Core.Exceptions;

namespace CookBook.Infrastructure.Exceptions
{
    public class InfrastructureException : BaseAppException
    {
        public HttpStatusCode StatusCode { get; set; }
        public InfrastructureException(string errorCode, string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(errorCode, errorMessage)
        {
            StatusCode = statusCode;
        }
    }
}

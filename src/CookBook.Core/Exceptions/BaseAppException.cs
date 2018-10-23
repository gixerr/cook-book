using System;

namespace CookBook.Core.Exceptions
{
    public abstract class BaseAppException : Exception
    {
        protected string ErrorCode { get; }

        protected BaseAppException()
        {
        }

        public BaseAppException(string errorCode, string message)
            : this (errorCode, null, message)
        {
        }

        protected BaseAppException(string errorCode, Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
namespace CookBook.Core.Exceptions
{
    public class CoreException : BaseAppException
    {
        public CoreException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}
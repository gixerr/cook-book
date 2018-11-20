namespace CookBook.Infrastructure.Exceptions
{
    public static class ErrorCode
    {
        public static string NotFound => nameof(NotFound);
        public static string CategoryExists => nameof(CategoryExists);
    }
}
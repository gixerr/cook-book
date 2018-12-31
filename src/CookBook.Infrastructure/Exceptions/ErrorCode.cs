namespace CookBook.Infrastructure.Exceptions
{
    public static class ErrorCode
    {
        public static string NotFound => nameof(NotFound);
        public static string CategoryExists => nameof(CategoryExists);
        public static string RecipeExists => nameof(RecipeExists);
        public static string IngredientExists => nameof(IngredientExists);
        public static string InvalidDataProvider => nameof(InvalidDataProvider);
    }
}

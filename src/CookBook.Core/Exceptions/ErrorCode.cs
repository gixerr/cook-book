namespace CookBook.Core.Exceptions
{
    public class ErrorCode
    {
        public static string EmptyModelProperty => nameof(EmptyModelProperty);
        public static string EmptyRecipeIngredient => nameof(EmptyRecipeIngredient);
        public static string IngredientExists => nameof(EmptyRecipeIngredient);
    }
}
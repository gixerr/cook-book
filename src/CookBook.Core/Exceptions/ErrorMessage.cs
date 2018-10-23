namespace CookBook.Core.Exceptions
{
    public class ErrorMessage
    {
        public static string EmptyRecipeName => "Recipe name can not be empty.";
        public static string EmptyIngredientName => "Ingredient name can not be empty";
        public static string EmptyCategoryName => "Category name can not be empty.";
        public static string EmptyRecipeIngredientName => "Recipe ingredient name can not be empty.";
        public static string EmptyIngredientCategoryName => "Ingredient Category name can not be null.";
        public static string EmptyRecipeCategory => "Recipe category can not be empty.";
        public static string EmptyIngredientCategory => "Ingredient category can not be empty";
        public static string EmptyRecipePreparation => "Recipe preparation can not be empty.";
        public static string EmptyRecipeIngredientCategory => "Recipe ingredient category can not be empty.";
        public static string EmptyRecipeIngredientMeasure => "Recipe ingredient measure can not be empty.";
        public static string InvalidRecipeIngredientAmount => "Recipe ingredient amount must be greater than 0.";
        public static string EmptyIngredientList => "Ingredient list can not be empty.";
    }
}
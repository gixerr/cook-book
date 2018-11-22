namespace CookBook.Infrastructure.Exceptions
{
    public static class ErrorMessage
    {
        public static string NoRecipeCategories => "No recipe categories availible.";
        public static string NoIngredientCategories => "No ingredient categories availible.";
        public static string NoRecipes => "No recipes availible.";
        public static string NoIngredients => "No ingredients availible.";
        public static string CategoryNotFound(string identifier) => $"Categoty '{identifier}' not found.";
        public static string CategoryExists(string identifier) => $"Category '{identifier}' already exists.";
        internal static string IngredientNotFound(string identifier) => $"Ingredient '{identifier}' not found.";
        internal static string RecipeNotFound(string identifier) => $"Recipe '{identifier}' not found.";
        internal static string RecipeWithCategoryNotFound(string identifier) => $"Recipe with category '{identifier}' not found.";
        internal static string RecipeExists(string identifier) => $"Recipe '{identifier}' already exists";
        internal static string IngredientExists(string identifier) => $"Ingredient '{identifier}' already exists";
    }
}

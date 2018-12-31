namespace CookBook.Infrastructure.Exceptions
{
    public static class ErrorMessage
    {
        public static string NoIngredientCategories => "No ingredient categories availible.";
        public static string NoRecipes => "No recipes availible.";
        public static string NoRecipeCategories => "No recipe categories availible.";
        public static string NoIngredients => "No ingredients availible.";
        public static string InvalidDataProvider(string indetifier) => $"'{indetifier}' data provider is invalid.";
        public static string CategoryNotFound(string identifier) => $"Categoty '{identifier}' not found.";
        public static string CategoryExists(string identifier) => $"Category '{identifier}' already exists.";
        public static string IngredientNotFound(string identifier) => $"Ingredient '{identifier}' not found.";
        public static string RecipeNotFound(string identifier) => $"Recipe '{identifier}' not found.";
        public static string RecipeWithCategoryNotFound(string identifier) => $"Recipe with category '{identifier}' not found.";
        public static string RecipeExists(string identifier) => $"Recipe '{identifier}' already exists";
        public static string IngredientExists(string identifier) => $"Ingredient '{identifier}' already exists";
    }
}

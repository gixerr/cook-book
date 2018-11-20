using System;

namespace CookBook.Infrastructure.Exceptions
{
    public static class ErrorMessage
    {
        public static string NoRecipeCategories => "No recipe categories availible.";
        public static string NoIngredientCategories => "No ingredient categories availible.";
        public static string CategoryNotFound(string identifier) => $"Categoty '{identifier}' not found.";
        public static string CategoryExists(string identifier) => $"Category '{identifier}' already exists.";
        internal static string IngredientNotFound(string identifier) => $"Ingredient '{identifier}' not found.";
    }
}
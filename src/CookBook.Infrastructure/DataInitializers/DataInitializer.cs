using System.Threading.Tasks;
using CookBook.Infrastructure.DataInitializers.Interfaces;

namespace CookBook.Infrastructure.DataInitializers
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IRecipeDataInitializer _recipeDataInitializer;
        private readonly IRecipeCategoryDataInitializer _recipeCategoryDataInitializer;
        private readonly IIngredientDataInitializer _ingredientDataInitializer;
        private readonly IIngredientCategoryDataInitializer _ingredientCategoryDataInitializer;

        public DataInitializer(IRecipeDataInitializer recipeDataInitializer,
            IRecipeCategoryDataInitializer recipeCategoryDataInitializer,
            IIngredientDataInitializer ingredientDataInitializer,
            IIngredientCategoryDataInitializer ingredientCategoryDataInitializer)
        {
            _recipeDataInitializer = recipeDataInitializer;
            _recipeCategoryDataInitializer = recipeCategoryDataInitializer;
            _ingredientDataInitializer = ingredientDataInitializer;
            _ingredientCategoryDataInitializer = ingredientCategoryDataInitializer;
        }

        public async Task Initialize()
        {
            await _ingredientCategoryDataInitializer.Initialize();
            await _recipeCategoryDataInitializer.Initialize();
            await _ingredientDataInitializer.Initialize();
            await _recipeDataInitializer.Initialize();
        }
    }
}

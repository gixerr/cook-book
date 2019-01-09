using System.Threading.Tasks;
using CookBook.Infrastructure.Dto;

namespace CookBook.Infrastructure.Services.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task AddIngredientAsync(RecipeIngredientAddDto recipeIngredientDto);
        Task RemoveIngredientAsync(RecipeIngredientRemoveDto recipeIngredientDto);
    }
}

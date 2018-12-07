using System.Threading.Tasks;

namespace CookBook.Infrastructure.DataInitializers.Interfaces
{
    public interface IIngredientDataInitializer
    {
        Task Initialize();
    }
}

using System.Threading.Tasks;

namespace CookBook.Infrastructure.DataInitializers.Interfaces
{
    public interface IRecipeDataInitializer
    {
        Task Initialize();
    }
}

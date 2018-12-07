using System.Threading.Tasks;

namespace CookBook.Infrastructure.DataInitializers.Interfaces
{
    public interface IDataInitializer
    {
        Task Initialize();
    }
}

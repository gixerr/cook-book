using System.Threading.Tasks;
using System.Windows.Input;

namespace CookBook.Infrastructure.CommandHandlers.Interfaces
{
    public interface ICommandHandler<T>
    {
        Task HandleAsync(T command);
    }
}

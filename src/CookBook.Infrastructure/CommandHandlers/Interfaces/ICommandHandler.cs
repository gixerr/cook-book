using System.Threading.Tasks;

namespace CookBook.Infrastructure.CommandHandlers.Interfaces
{
    public interface ICommandHandler<T>
    {
        Task HandleAsync(T command);
    }
}

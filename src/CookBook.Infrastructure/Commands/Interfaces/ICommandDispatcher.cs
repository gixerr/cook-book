using System.Threading.Tasks;

namespace CookBook.Infrastructure.Commands.Interfaces
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}

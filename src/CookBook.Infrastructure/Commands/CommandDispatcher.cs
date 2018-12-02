using System;
using System.Threading.Tasks;
using Autofac;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), $"Command '{typeof(T).Name} cannot be null");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            if (handler is null)
            {
                throw new ArgumentNullException(nameof(command), $"Command handler '{typeof(T).Name} not found.");
            }
            await handler.HandleAsync(command);
        }
    }
}

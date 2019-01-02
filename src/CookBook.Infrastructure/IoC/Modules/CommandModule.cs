using Autofac;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Commands;
using CookBook.Infrastructure.Commands.Interfaces;

namespace CookBook.Infrastructure.IoC.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var infrastructureAssembly = typeof(CommandModule).Assembly;
            builder.RegisterAssemblyTypes(infrastructureAssembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>()
                   .InstancePerLifetimeScope();
        }
    }
}

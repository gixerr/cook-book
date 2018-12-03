using Autofac;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Api.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterAppTypes(this ContainerBuilder builder)
        {
            var infrastructureAssembly = typeof(IRecipeService).Assembly;
            builder.RegisterAssemblyTypes(infrastructureAssembly)
                   .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(infrastructureAssembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            return builder;
        }
    }
}

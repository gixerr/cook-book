using System;
using Autofac;
using CookBook.Api.Settings;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Exceptions;
using CookBook.Infrastructure.IoC.Modules;
using CookBook.Infrastructure.Mappings;
using Microsoft.Extensions.Configuration;

namespace CookBook.Api.Extensions
{
    public static class ContainerBuilderExtensions
    {
        //TODO: Refactor this method
        public static ContainerBuilder RegisterDataProviderModule(this ContainerBuilder builder,
            IConfiguration configuration)
        {
            var persistence = new PersistenceSettings();
            configuration.GetSection("persistence").Bind(persistence);
            if (persistence.ProviderType.Equals("inMemory", StringComparison.OrdinalIgnoreCase))
            {
                builder.RegisterModule<InMemoryRepositoryModule>();

                return builder;
            }
            if (persistence.ProviderType.Equals("sql", StringComparison.OrdinalIgnoreCase))
            {
                builder.RegisterModule<EntityFrameworkRepositoryModule>();

                return builder;
            }
            throw new InfrastructureException(ErrorCode.InvalidDataProvider,
                ErrorMessage.InvalidDataProvider(persistence.ProviderType));
        }

        public static ContainerBuilder RegisterCommandModule(this ContainerBuilder builder)
        {
            var infrastructureAssembly = typeof(CommandModule).Assembly;
            builder.RegisterAssemblyTypes(infrastructureAssembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder RegisterAutoMapper(this ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.GetMapper())
                   .SingleInstance();

            return builder;
        }
    }
}

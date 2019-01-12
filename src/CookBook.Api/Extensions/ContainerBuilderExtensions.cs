using Autofac;
using CookBook.Api.Providers;
using CookBook.Api.Settings;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Exceptions;
using CookBook.Infrastructure.IoC.Modules;
using CookBook.Infrastructure.Mappings;
using CookBook.Infrastructure.Services;
using CookBook.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CookBook.Api.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder RegisterRepositoryModule(this ContainerBuilder builder,
            string providerType)
        {
            DataProviders.SetProvider(builder, providerType);

            return builder;
        }

        public static ContainerBuilder RegisterServicesModule(this ContainerBuilder builder)
        {
            builder.RegisterModule<ServicesModule>();

            return builder;
        }

        public static ContainerBuilder RegisterCommandModule(this ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();

            return builder;
        }

        public static ContainerBuilder RegisterAutoMapper(this ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.GetMapper())
                .SingleInstance();

            return builder;
        }

        public static ContainerBuilder RegisterDataInitializers(this ContainerBuilder builder)
        {
            builder.RegisterModule<DataInitializersModule>();

            return builder;
        }
    }
}

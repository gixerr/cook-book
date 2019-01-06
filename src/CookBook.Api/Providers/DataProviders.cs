using System;
using System.Collections.Generic;
using Autofac;
using CookBook.Infrastructure.IoC.Modules;

namespace CookBook.Api.Providers
{
    public class DataProviders
    {
        public static void SetProvider(ContainerBuilder builder, string providerType)
        {
            if (!Providers.ContainsKey(providerType))
            {
                throw new ArgumentException("Invalid data provider type.");
            }
            Providers[providerType](builder);
        }
        private static Dictionary<string, Action<ContainerBuilder>> Providers = new Dictionary<string, Action<ContainerBuilder>>()
        {
            ["inMemory"] = builder => builder.RegisterModule<InMemoryRepositoryModule>(),
            ["sql"] = builder => builder.RegisterModule<EntityFrameworkRepositoryModule>()
        };
    }
}
using Autofac;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.Repositories.InMemory;

namespace CookBook.Infrastructure.IoC.Modules
{
    public class InMemoryRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryRecipeRepository>().As<IRecipeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InMemoryIngredientRepository>().As<IIngredientRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InMemoryRecipeCategoryRepository>().As<IRecipeCategoryRepository>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<InMemoryIngredientCategoryRepository>().As<IIngredientCategoryRepository>()
                   .InstancePerLifetimeScope();
        }
    }
}

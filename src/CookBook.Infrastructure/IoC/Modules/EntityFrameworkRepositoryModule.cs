using Autofac;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.Repositories.EntityFramework;

namespace CookBook.Infrastructure.IoC.Modules
{
    public class EntityFrameworkRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EntityFrameworkRecipeRepository>().As<IRecipeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkIngredientRepository>().As<IIngredientRepository>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkRecipeCategoryRepository>().As<IRecipeCategoryRepository>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkIngredientCategoryRepository>().As<IIngredientCategoryRepository>()
                   .InstancePerLifetimeScope();
        }
    }
}

using Autofac;
using CookBook.Infrastructure.Services;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.IoC.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RecipeService>().As<IRecipeService>().InstancePerLifetimeScope();
            builder.RegisterType<RecipeCategoryService>().As<IRecipeCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<IngredientService>().As<IIngredientService>().InstancePerLifetimeScope();
            builder.RegisterType<IngredientCategoryService>().As<IIngredientCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<RecipeIngredientService>().As<IRecipeIngredientService>().InstancePerLifetimeScope();
        }
    }
}

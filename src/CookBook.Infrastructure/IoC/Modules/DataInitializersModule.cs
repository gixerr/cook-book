using Autofac;
using CookBook.Infrastructure.DataInitializers;
using CookBook.Infrastructure.DataInitializers.Interfaces;

namespace CookBook.Infrastructure.IoC.Modules
{
    public class DataInitializersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataInitializer>().As<IDataInitializer>();
            builder.RegisterType<RecipeDataInitializer>().As<IRecipeDataInitializer>();
            builder.RegisterType<RecipeCategoryDataInitializer>().As<IRecipeCategoryDataInitializer>();
            builder.RegisterType<IngredientDataInitializer>().As<IIngredientDataInitializer>();
            builder.RegisterType<IngredientCategoryDataInitializer>().As<IIngredientCategoryDataInitializer>();
        }
    }
}
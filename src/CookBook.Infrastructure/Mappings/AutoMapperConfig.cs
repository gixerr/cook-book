using AutoMapper;
using CookBook.Core.Domain;
using CookBook.Infrastructure.Dto;

namespace CookBook.Infrastructure.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeDto>();
                cfg.CreateMap<RecipeCategory, RecipeCategoryDto>();
                cfg.CreateMap<Ingredient, IngredientCategoryDto>();
                cfg.CreateMap<IngredientCategory, IngredientCategoryDto>();
            }).CreateMapper();
    }
}

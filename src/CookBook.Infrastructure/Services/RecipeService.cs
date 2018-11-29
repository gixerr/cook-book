using AutoMapper;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Repositories.Extensions;
using CookBook.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeCategoryRepository _recipeCategoryRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IRecipeCategoryRepository recipeCategoryRepository,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _recipeCategoryRepository = recipeCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeDto>> GetAllAsync()
        {
            var recipes = await _recipeRepository.GetAllOrThrowAsync();

            return Dto(recipes);
        }

        public async Task<RecipeDto> GetAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetOrThrowAsync(id);

            return Dto(recipe);
        }

        public async Task<IEnumerable<RecipeDto>> GetAsync(string name)
        {
            var recipes = await _recipeRepository.GetOrThrowAsync(name);

            return Dto(recipes);
        }

        public async Task<IEnumerable<RecipeDto>> GetAsync(RecipeCategoryDto recipeCategoryDto)
        {
            var recipeCategory = await _recipeCategoryRepository.GetOrThrowAsync(recipeCategoryDto.Name);
            var recipes = await _recipeRepository.GetOrThrowAsync(recipeCategory);

            return Dto(recipes);
        }

        public async Task AddAsync(RecipeCreateDto recipeDto)
            => await _recipeRepository.AddOrThrowAsync(_recipeCategoryRepository, recipeDto);

        public async Task UpdateAsync(Guid id, RecipeUpdateDto recipeUpdateDto)
            => await _recipeRepository.UpdateOrThrowAsync(_recipeCategoryRepository, id, recipeUpdateDto);

        public async Task RemoveAsync(Guid id)
            => await _recipeRepository.RemoveOrThrowAsync(id);

        private RecipeDto Dto(Recipe model)
            => _mapper.Map<RecipeDto>(model);

        private IEnumerable<RecipeDto> Dto(IEnumerable<Recipe> modelCollection)
            => _mapper.Map<IEnumerable<RecipeDto>>(modelCollection);
    }
}

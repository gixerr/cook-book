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
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        private readonly IIngredientCategoryRepository _ingredientCategoryRepository;

        public IngredientService(IIngredientRepository ingredientRepository,
            IIngredientCategoryRepository ingredientCategoryRepository, IMapper mapper)
        {
            _ingredientCategoryRepository = ingredientCategoryRepository;
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            var ingredients = await _ingredientRepository.GetAllOrThrowAsync();

            return Dto(ingredients);
        }
        public async Task<IEnumerable<IngredientDto>> GetAsync(string name)
        {
            var ingredients = await _ingredientRepository.GetOrThrowAsync(name);

            return Dto(ingredients);
        }

        public async Task<IEnumerable<IngredientDto>> GetAsync(IngredientCategoryDto ingredientCategoryDto)
        {
            var ingredientCategory = await _ingredientCategoryRepository.GetOrThrowAsync(ingredientCategoryDto.Name);
            var ingredients = await _ingredientRepository.GetOrThrowAsync(ingredientCategory);

            return Dto(ingredients);
        }

        public async Task<IngredientDto> GetAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetOrThrowAsync(id);

            return Dto(ingredient);
        }

        public async Task AddAsync(IngredientCreateDto ingredientDto) 
            => await _ingredientRepository.AddOrThrowAsync(_ingredientCategoryRepository, ingredientDto);

        public async Task UpdateAsync(IngredientUpdateDto ingredientUpdateDto) 
            => await _ingredientRepository.UpdateOrThrowAsync(_ingredientCategoryRepository, ingredientUpdateDto);

        public async Task RemoveAsync(Guid id)
            => await _ingredientRepository.RemoveOrThrowAsync(id);

        private IngredientDto Dto(Ingredient model) 
            => _mapper.Map<IngredientDto>(model);

        private IEnumerable<IngredientDto> Dto(IEnumerable<Ingredient> modelCollection) 
            => _mapper.Map<IEnumerable<IngredientDto>>(modelCollection);

    }
}

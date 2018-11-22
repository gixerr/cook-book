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
    public class IngredientCategoryService : IIngredientCategoryService
    {
        private readonly IIngredientCategoryRepository _ingredientCategoryRepository;
        private readonly IMapper _mapper;
        public IngredientCategoryService(IIngredientCategoryRepository ingredientCategoryRepository, IMapper mapper)
        {
            _ingredientCategoryRepository = ingredientCategoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IngredientCategoryDto>> GetAllAsync()
        {
            var categories = await _ingredientCategoryRepository.GetAllOrThrowAsync();

            return Dto(categories);
        }

        public async Task<IngredientCategoryDto> GetAsync(Guid id)
        {
            var category = await _ingredientCategoryRepository.GetOrThrowAsync(id);

            return Dto(category);
        }

        public async Task<IngredientCategoryDto> GetAsync(string name)
        {
            var category = await _ingredientCategoryRepository.GetOrThrowAsync(name);

            return Dto(category);
        }

        public async Task AddAsync(IngredientCategoryCreateDto categoryDto)
            => await _ingredientCategoryRepository.AddOrThrowAsync(categoryDto);

        public async Task UpdateAsync(Guid categoryId, IngredientCategoryUpdateDto categoryDto)
            => await _ingredientCategoryRepository.UpdateOrThrowAsync(categoryId, categoryDto);

        public async Task RemoveAsync(Guid id)
            => await _ingredientCategoryRepository.RemoveOrThrowAsync(id);

        private IngredientCategoryDto Dto(IngredientCategory model)
            => _mapper.Map<IngredientCategoryDto>(model);

        private IEnumerable<IngredientCategoryDto> Dto(IEnumerable<IngredientCategory> modelCollection)
            => _mapper.Map<IEnumerable<IngredientCategoryDto>>(modelCollection);
    }
}

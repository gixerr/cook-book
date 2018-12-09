using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;
using CookBook.Infrastructure.Repositories.Extensions;
using CookBook.Core.Domain;

namespace CookBook.Infrastructure.Services
{
    public class RecipeCategoryService : IRecipeCategoryService
    {
        private readonly IRecipeCategoryRepository _recipeCategoryRepository;
        private readonly IMapper _mapper;

        public RecipeCategoryService(IRecipeCategoryRepository recipeCategoryRepository, IMapper mapper)
        {
            _recipeCategoryRepository = recipeCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeCategoryDto>> GetAllAsync()
        {
            var categories = await _recipeCategoryRepository.GetAllOrThrowAsync();

            return Dto(categories);
        }

        public async Task<RecipeCategoryDto> GetAsync(Guid id)
        {
            var category = await _recipeCategoryRepository.GetOrThrowAsync(id);

            return Dto(category);
        }

        public async Task<RecipeCategoryDto> GetAsync(string name)
        {
            var category = await _recipeCategoryRepository.GetOrThrowAsync(name);

            return Dto(category);
        }

        public async Task AddAsync(RecipeCategoryCreateDto categoryDto)
            => await _recipeCategoryRepository.AddOrThrowAsync(categoryDto);

        public async Task UpdateAsync(RecipeCategoryUpdateDto categoryDto)
            => await _recipeCategoryRepository.UpdateOrThrowAsync(categoryDto);

        public async Task RemoveAsync(Guid id)
            => await _recipeCategoryRepository.RemoveOrThrowAsync(id);

        private RecipeCategoryDto Dto(RecipeCategory model)
            => _mapper.Map<RecipeCategoryDto>(model);
        
        private IEnumerable<RecipeCategoryDto> Dto(IEnumerable<RecipeCategory> modelCollection)
            => _mapper.Map<IEnumerable<RecipeCategoryDto>>(modelCollection);
    }
}

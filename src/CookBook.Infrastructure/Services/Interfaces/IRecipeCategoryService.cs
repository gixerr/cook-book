using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Infrastructure.Dto;

namespace CookBook.Infrastructure.Services.Interfaces
{
    public interface IRecipeCategoryService
    {
        Task<IEnumerable<RecipeCategoryDto>> GetAllAsync();
        Task<RecipeCategoryDto> GetAsync(Guid id);
        Task<RecipeCategoryDto> GetAsync(string name);
        Task AddAsync(RecipeCategoryCreateDto categoryDto);
        Task UpdateAsync(RecipeCategoryUpdateDto categoryDto);
        Task RemoveAsync(Guid id);
    }
}

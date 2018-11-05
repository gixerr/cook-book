﻿using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Repositories
{
    public class InMemoryRecipeCategoryRepository : IRecipeCategoryRepository
    {
        private static readonly ISet<RecipeCategory> Categories = new HashSet<RecipeCategory>();

        public async Task<IEnumerable<RecipeCategory>> GetAllAsync()
            => await Task.FromResult(Categories);

        public async Task<RecipeCategory> GetAsync(Guid id)
            => await Task.FromResult(Categories.SingleOrDefault(x => x.Id.Equals(id)));

        public async Task<RecipeCategory> GetAsync(string name)
            => await Task.FromResult(Categories.SingleOrDefault(
                x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));

        public async Task AddAsync(RecipeCategory recipeCategory)
            => await Task.FromResult(Categories.Add(recipeCategory));

        public async Task UpdateAsync(RecipeCategory category)
            => await Task.CompletedTask;

        public async Task RemoveAsync(Guid id)
            => Categories.Remove(await GetAsync(id));
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<Category>> GetCategorysAsync();
        Task<Category> GetCategoryByIdAsync(int Id);
        Task<Category> PostCategory(Category Category);
        Task<Category> DeleteCategory(int id);
        Task<Category> PutCategory(Category Category);
    }
}
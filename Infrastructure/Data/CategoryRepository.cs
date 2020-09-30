
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetContext _context;
        public CategoryRepository(BudgetContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Category>> GetCategorysAsync()
        {
            return await _context.Category.ToListAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Category.FindAsync(id);
        }
        public async Task<Category> PostCategory(Category Category)
        {
            _context.Set<Category>().Add(Category);
            await _context.SaveChangesAsync();
            return Category;
        }
        public async Task<Category> DeleteCategory(int id)
        {
            var entity = await _context.Set<Category>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<Category>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<Category> PutCategory(Category Category)
        {
            _context.Entry(Category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Category;
        }
    }
}

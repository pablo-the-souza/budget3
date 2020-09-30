
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RecordRepository : IRecordRepository
    {
        private readonly BudgetContext _context;
        public RecordRepository(BudgetContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Record>> GetRecordsAsync()
        {
            return await _context.Record
            .Include(r => r.Category)
            .ToListAsync()
            ;
        }
        public async Task<Record> GetRecordByIdAsync(int id)
        {
            return await _context.Record
            .Include(r => r.Category)
            .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<Record> PostRecord(Record Record)
        {
            _context.Set<Record>().Add(Record);
            await _context.SaveChangesAsync();
            return Record;
        }
        public async Task<Record> DeleteRecord(int id)
        {
            var entity = await _context.Set<Record>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<Record>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<Record> PutRecord(Record Record)
        {
            _context.Entry(Record).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Record;
        }
        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.Category
            .Include(c => c.Records)
            .ToListAsync();
        }
    }
}

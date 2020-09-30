using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRecordRepository
    {
        Task<IReadOnlyList<Record>> GetRecordsAsync();
        Task<Record> GetRecordByIdAsync(int Id);
        Task<Record> PostRecord(Record Record);
        Task<Record> DeleteRecord(int id);
        Task<Record> PutRecord(Record Record);
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}
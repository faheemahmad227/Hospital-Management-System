using Microsoft.EntityFrameworkCore;
using PatientRecordsService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRecordsService.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly PatientRecordDbContext context;
        public GenericRepository(PatientRecordDbContext context)
        {
            this.context = context;
        }
        public T Add(T item)
        {
            return context.Add(item).Entity;
        }
        public T Delete(T item)
        {
            return context.Remove(item).Entity;
        }
        public T Update(T item)
        {
            return context.Update(item).Entity;
        }
        public async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    
    }
}

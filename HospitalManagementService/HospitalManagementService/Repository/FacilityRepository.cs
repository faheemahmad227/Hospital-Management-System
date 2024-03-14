using HospitalManagementService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementService.Repository
{
    public class FacilityRepository<T> : IFacilityRepository<T> where T : class
    {
        private readonly HospitalManagementContext context;
        public FacilityRepository(HospitalManagementContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {
            return context.Add(item).Entity;
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
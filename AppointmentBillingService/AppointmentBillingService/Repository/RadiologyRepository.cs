using AppointmentBillingService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Repository
{
    public class RadiologyRepository<T> : IRepository<T> where T : class
    {
        private readonly AppointmentDbContext context;
        public RadiologyRepository(AppointmentDbContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {
            throw new NotImplementedException();
        }

        public Task<AmbulanceService> GetAmbulanceById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<T>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Consultation> GetConsultationById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ECGService> GetECGById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<LaboratoryService> GetLabTestsById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<PhysiotherapyService> GetPhysioById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<RadiologyService> GetRadioById(int? id)
        {
            RadiologyService radiologyService = await context.RadiologyService.FirstAsync(p => p.RadiologyServiceId == id);
            return radiologyService;
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}

using AppointmentBillingService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class

    {
        private readonly AppointmentDbContext context;
        public GenericRepository(AppointmentDbContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {
            return context.Add(item).Entity;
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

        public async Task<Consultation> GetConsultationById(int? id)
        {
            Consultation consultation = await context.Consultations.FirstAsync(p => p.ConsultationId == id);
            return consultation;
        }

        public async Task<LaboratoryService> GetLabTestsById(int? id)
        {
            LaboratoryService laboratoryService = await context.LaboratoryServices.FirstAsync(p => p.LaboratoryServiceId == id);
            return laboratoryService;
        }

        public async Task<ECGService> GetECGById(int? id)
        {
            ECGService eCGService = await context.ECGServices.FirstAsync(p => p.ECGServiceId == id);
            return eCGService;
        }

        public async Task<PhysiotherapyService> GetPhysioById(int? id)
        {
            PhysiotherapyService physiotherapyService = await context.PhysiotherapyServices.FirstAsync(p => p.PhysiotherapyServiceId == id);
            return physiotherapyService;
        }

        public async Task<RadiologyService> GetRadioById(int? id)
        {
            RadiologyService radiologyService = await context.RadiologyService.FirstAsync(p => p.RadiologyServiceId == id);
            return radiologyService;
        }

        public async Task<AmbulanceService> GetAmbulanceById(int? id)
        {
            AmbulanceService ambulance = await context.AmbulanceServices.FirstAsync(p => p.AmbulanceServiceId == id);
            return ambulance;
        }
    }
}

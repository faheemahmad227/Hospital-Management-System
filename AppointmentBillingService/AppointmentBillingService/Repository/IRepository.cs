using AppointmentBillingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T item);
        T Update(T item);
        Task<IReadOnlyCollection<T>> GetAsync();
        Task<Consultation> GetConsultationById(int? id);
        Task<LaboratoryService> GetLabTestsById(int? id);
        Task<ECGService> GetECGById(int? id);
        Task<PhysiotherapyService> GetPhysioById(int? id);
        Task<RadiologyService> GetRadioById(int? id);
        Task<AmbulanceService> GetAmbulanceById(int? id);
        Task<T> GetAsync(int id);
        Task<int> SaveAsync();
    }

}

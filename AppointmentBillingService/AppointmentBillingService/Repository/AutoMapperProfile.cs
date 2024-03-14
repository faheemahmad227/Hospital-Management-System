using AppointmentBillingService.DTOs;
using AppointmentBillingService.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppointmentDTO, Appointment>().ReverseMap();
            CreateMap<FacilityAptDTO, FacilityAppointment>().ReverseMap();
            CreateMap<AmbulanceServiceDTO, AmbulanceService>().ReverseMap();
            CreateMap<ConsultationDTO, Consultation>().ReverseMap();
            CreateMap<ECGServiceDTO, ECGService>().ReverseMap();
            CreateMap<LaboratoryServiceDTO, LaboratoryService>().ReverseMap();
            CreateMap<PhysiotherapyServiceDTO, PhysiotherapyService>().ReverseMap();
            CreateMap<RadiologyServiceDTO, RadiologyService>().ReverseMap();
            CreateMap<BillingDTO, Billing>().ReverseMap();
        }
    }
}

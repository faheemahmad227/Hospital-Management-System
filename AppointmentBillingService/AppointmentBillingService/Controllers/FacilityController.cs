using AppointmentBillingService.DTOs;
using AppointmentBillingService.Models;
using AppointmentBillingService.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly AppointmentDbContext context;
        private readonly IRepository<FacilityAppointment> facilityAppontmentsRepository;
        private readonly IRepository<AmbulanceService> AmbulanceServicesRepository;
        private readonly IRepository<PhysiotherapyService> PhysiotherapyServiceesRepository;
        private readonly IRepository<LaboratoryService> LaboratoryServicesRepository;
        private readonly IRepository<ECGService> ECGServicesRepository;
        private readonly IRepository<RadiologyService> RadiologyServicesRepository;
        private readonly IRepository<Consultation> ConsultationsRepository;
        private readonly IMapper mapper;
        public FacilityController(AppointmentDbContext context,
            IRepository<FacilityAppointment> facilityAppontmentsRepository,
            IRepository<AmbulanceService> AmbulanceServicesRepository,
            IRepository<PhysiotherapyService> PhysiotherapyServiceesRepository,
            IRepository<LaboratoryService> LaboratoryServicesRepository,
            IRepository<ECGService> ECGServicesRepository,
            IRepository<RadiologyService> RadiologyServicesRepository,
            IRepository<Consultation> ConsultationsRepository, IMapper mapper)


        {
            this.context = context;
            this.facilityAppontmentsRepository = facilityAppontmentsRepository;
            this.AmbulanceServicesRepository = AmbulanceServicesRepository;
            this.LaboratoryServicesRepository = LaboratoryServicesRepository;
            this.PhysiotherapyServiceesRepository = PhysiotherapyServiceesRepository;
            this.ECGServicesRepository = ECGServicesRepository;
            this.RadiologyServicesRepository = RadiologyServicesRepository;
            this.ConsultationsRepository = ConsultationsRepository;


            this.mapper = mapper;
        }
        [HttpGet("FacilitiesInfo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FacilityAptDTO>))]
        public async Task<IActionResult> GetFacilities()
        {
            IEnumerable<FacilityAppointment> facilityApt = await facilityAppontmentsRepository.GetAsync();

            var DTOs = mapper.Map<List<FacilityAptDTO>>(facilityApt);
            return Ok(DTOs);
        }
        [HttpGet("[action]")]
        public async Task<FacilityAppointment> GetByAppontmentById(int id)
        {
            FacilityAppointment facility = await context.FacilityAppointments.FirstAsync(p => p.AppointmentId == id);
            return facility;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AppointmentDTO))]
        public async Task<IActionResult> Get(int id)
        {
            FacilityAppointment appointment = await facilityAppontmentsRepository.GetAsync(id);

            var DTO = mapper.Map<FacilityAptDTO>(appointment);
            return Ok(DTO);
        }
        [HttpPost("ChooseFacility")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]
        public async Task<IActionResult> Post(FacilityAptDTO model)
        {
            FacilityAppointment facilityApt = mapper.Map<FacilityAppointment>(model);
            facilityAppontmentsRepository.Add(facilityApt);
            await facilityAppontmentsRepository.SaveAsync();
            var dto = mapper.Map<FacilityAptDTO>(facilityApt);

            return StatusCode(200, dto);
        }
        [HttpPut("Update")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]
        public async Task<IActionResult> Put(FacilityAptDTO model)
        {
            FacilityAppointment appointment = mapper.Map<FacilityAppointment>(model);
            facilityAppontmentsRepository.Update(appointment);
            await facilityAppontmentsRepository.SaveAsync();
            var dto = mapper.Map<FacilityAptDTO>(appointment);
            return Ok(dto);
        }
        [HttpGet("GetByAppontmentId")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetFacility(int AppontmentId)
        {

            IEnumerable<FacilityAppointment> facilityApt = await facilityAppontmentsRepository.GetAsync();

            var facility = facilityApt
                   .Where(f => f.AppointmentId == AppontmentId);


            return Ok(facility);
        }
        [HttpGet("AmbulanceService")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AmbulanceServiceDTO>))]
        public async Task<IActionResult> GetAmbulanceService()
        {
            IEnumerable<AmbulanceService> labTests = await AmbulanceServicesRepository.GetAsync();

            var DTOs = mapper.Map<List<AmbulanceServiceDTO>>(labTests);
            return Ok(DTOs);
        }
        [HttpGet("PhysiotherapyService")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PhysiotherapyServiceDTO>))]
        public async Task<IActionResult> GetPhysiotherapyService()
        {
            IEnumerable<PhysiotherapyService> labTests = await PhysiotherapyServiceesRepository.GetAsync();

            var DTOs = mapper.Map<List<PhysiotherapyServiceDTO>>(labTests);
            return Ok(DTOs);
        }
        [HttpGet("LaboratoryService")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LaboratoryServiceDTO>))]
        public async Task<IActionResult> GetLaboratoryService()
        {
            IEnumerable<LaboratoryService> labTests = await LaboratoryServicesRepository.GetAsync();

            var DTOs = mapper.Map<List<LaboratoryServiceDTO>>(labTests);
            return Ok(DTOs);
        }
        [HttpGet("ECGService")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ECGServiceDTO>))]
        public async Task<IActionResult> GetECGService()
        {
            IEnumerable<ECGService> labTests = await ECGServicesRepository.GetAsync();

            var DTOs = mapper.Map<List<ECGServiceDTO>>(labTests);
            return Ok(DTOs);
        }
        [HttpGet("RadiologyService")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RadiologyServiceDTO>))]
        public async Task<IActionResult> GetRadiologyService()
        {
            IEnumerable<RadiologyService> labTests = await RadiologyServicesRepository.GetAsync();

            var DTOs = mapper.Map<List<RadiologyServiceDTO>>(labTests);
            return Ok(DTOs);
        }
        [HttpGet("Consultation")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConsultationDTO>))]
        public async Task<IActionResult> GetConsultation()
        {
            IEnumerable<Consultation> labTests = await ConsultationsRepository.GetAsync();

            var DTOs = mapper.Map<List<ConsultationDTO>>(labTests);
            return Ok(DTOs);
        }

    }
}

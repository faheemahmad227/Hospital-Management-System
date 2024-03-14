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
    public class BillingController : ControllerBase
    {
        private readonly AppointmentDbContext context;
        private readonly IRepository<Billing> BillingRepository;
        private readonly IRepository<FacilityAppointment> facilityAppontmentsRepository;
        private readonly IRepository<AmbulanceService> ambulanceService;
        private readonly IRepository<Consultation> consultation;
        private readonly IRepository<ECGService> eCGService;
        private readonly IRepository<LaboratoryService> laboratoryService;
        private readonly IRepository<PhysiotherapyService> physiotherapyService;
        private readonly IRepository<RadiologyService> radiologyService;
        private readonly IMapper mapper;
        public BillingController(AppointmentDbContext context,IRepository<Billing> BillingRepository, IRepository<FacilityAppointment> facilityAppontmentsRepository, IMapper mapper,
           IRepository<AmbulanceService> ambulanceService, IRepository<Consultation> consultation, IRepository<ECGService> eCGService,
            IRepository<LaboratoryService> laboratoryService, IRepository<PhysiotherapyService> physiotherapyService, IRepository<RadiologyService> radiologyService)
        {
            this.context = context;
            this.facilityAppontmentsRepository = facilityAppontmentsRepository; ;
            this.BillingRepository = BillingRepository;
            this.mapper = mapper;
            this.ambulanceService = ambulanceService;
            this.consultation = consultation;
            this.eCGService = eCGService;
            this.laboratoryService = laboratoryService;
            this.physiotherapyService = physiotherapyService;
            this.radiologyService = radiologyService;
        }

        [HttpGet("GetCharges")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BillingDTO>))]
        public async Task<IActionResult> GetCharges()
        {
            IEnumerable<Billing> billing = await BillingRepository.GetAsync();

            var DTOs = mapper.Map<List<BillingDTO>>(billing);
            return Ok(DTOs);
        }
        [HttpGet]
        [Route("[action]/{AppointmentId}")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetByAppontmentById(int AppointmentId)
        {

            IEnumerable<FacilityAppointment> facilityApt = await facilityAppontmentsRepository.GetAsync();

            var facility = facilityApt
                   .Where(f => f.AppointmentId == AppointmentId);


            return Ok(facility);
        }
        [HttpGet]
        [Route("[action]/{PhysiotherapyServiceId}")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetByPhysiotherapyServiceById(int? PhysiotherapyServiceId)
        {

                var labtest = await physiotherapyService.GetPhysioById(PhysiotherapyServiceId);
                return Ok(labtest);
        }
        [HttpGet]
        [Route("[action]/{LaboratoryServiceId}")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetByLaboratoryServicebyId(int? LaboratoryServiceId)
        {
                var labtest = await laboratoryService.GetLabTestsById(LaboratoryServiceId);
                return Ok(labtest);
        }
        [HttpGet]
        [Route("[action]/{ECGServiceId}")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetByECGServicebyId(int? ECGServiceId)
        {
                var labtest = await eCGService.GetECGById(ECGServiceId);
                return Ok(labtest);
        }
        [HttpGet]
        [Route("[action]/{RadiologyServiceId}")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetByRadiologyServicebyId(int? RadiologyServiceId)
        {
                var labtest = await radiologyService.GetRadioById(RadiologyServiceId);
                return Ok(labtest);
        }
        [HttpGet]
        [Route("[action]/{AmbulanceServiceId}")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetByAmbulanceServicebyId(int? AmbulanceServiceId)
        {
                var labtest = await ambulanceService.GetAmbulanceById(AmbulanceServiceId);
                return Ok(labtest);
        }
        [HttpGet]
        [Route("[action]/{ConsultationId}")]
        [ProducesResponseType(200, Type = typeof(FacilityAptDTO))]

        public async Task<IActionResult> GetByConsultationbyId(int? ConsultationId)
        {
                var labtest = await consultation.GetConsultationById(ConsultationId);
                return Ok(labtest);
        }
        [HttpPost("Charges")]
        [ProducesResponseType(200, Type = typeof(BillingDTO))]
        public async Task<IActionResult> Post(Billing model)
        {
            BillingRepository.Add(model);
            await BillingRepository.SaveAsync();

            return StatusCode(200, model);
        }
    }
}


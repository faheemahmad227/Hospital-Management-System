using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatientRecordsService.DTO;
using PatientRecordsService.Models;
using PatientRecordsService.Repository;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatientRecordsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTreatmentController : ControllerBase
    {
        private readonly IRepository<PatientTreatmentDetails> patientTreatment;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public PatientTreatmentController(IRepository<PatientTreatmentDetails> patientTreatment, IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.patientTreatment = patientTreatment;
            this.configuration = configuration;
        }
        [HttpGet("GetTreatmentList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PatientTreatmentDetailsDTO>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<PatientTreatmentDetails> patient = await patientTreatment.GetAsync();
            var DTOs = mapper.Map<List<PatientTreatmentDetailsDTO>>(patient);
            return Ok(DTOs);
        }
        [HttpPost("AddTreatmentDetails")]
        [ProducesResponseType(200, Type = typeof(PatientTreatmentDetailsDTO))]
        public async Task<IActionResult> Post(PatientTreatmentDetailsDTO model)
        {
            PatientTreatmentDetails hospital = mapper.Map<PatientTreatmentDetails>(model);
            patientTreatment.Add(hospital);
            await patientTreatment.SaveAsync();
            var dto = mapper.Map<PatientTreatmentDetailsDTO>(hospital);
            try
            {
                var json = JsonSerializer.Serialize(hospital);
            }
            catch { }
            return StatusCode(200, dto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PatientTreatmentDetailsDTO))]
        public async Task<IActionResult> Get(int id)
        {
            PatientTreatmentDetails trainer = await patientTreatment.GetAsync(id);
            var DTO = mapper.Map<PatientTreatmentDetailsDTO>(trainer);
            return Ok(DTO);
        }
        [HttpPut("UpdateTreatmentDetails")]
        [ProducesResponseType(200, Type = typeof(PatientTreatmentDetailsDTO))]
        public async Task<IActionResult> Put(PatientTreatmentDetailsDTO model)
        {
            PatientTreatmentDetails hospital = mapper.Map<PatientTreatmentDetails>(model);
            patientTreatment.Update(hospital);
            await patientTreatment.SaveAsync();
            var dto = mapper.Map<PatientTreatmentDetailsDTO>(hospital);
            return Ok(dto);
        }
    }
}

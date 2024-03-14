using AutoMapper;
using FeedbackService.Model;
using FeedbackService.Model.DTO;
using FeedbackService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FeedbackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityFeedbackController : ControllerBase
    {
        private readonly IFeedbackService<FacilityFeedback> facilityFeedback;
        private readonly IMapper mapper;
        public FacilityFeedbackController(IMapper mapper, IFeedbackService<FacilityFeedback> facilityFeedback)
        {
            this.mapper = mapper;
            this.facilityFeedback = facilityFeedback;
        }
        [HttpGet("Facility")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FacilityFeedbackDTO>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<FacilityFeedback> feedback = await facilityFeedback.GetAsync();
            var DTOs = mapper.Map<List<FacilityFeedbackDTO>>(feedback);
            return Ok(DTOs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DoctorFeedbackDTO))]
        public async Task<IActionResult> Get(int id)
        {
            FacilityFeedback feedback = await facilityFeedback.GetAsync(id);

            var DTO = mapper.Map<FacilityFeedbackDTO>(feedback);
            return Ok(DTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FacilityFeedbackDTO))]
        public async Task<IActionResult> Post(FacilityFeedbackDTO model)
        {
            FacilityFeedback feedback = mapper.Map<FacilityFeedback>(model);
            facilityFeedback.Add(feedback);
            await facilityFeedback.SaveAsync();
            var dto = mapper.Map<FacilityFeedbackDTO>(feedback);

            try
            {
                var json = JsonSerializer.Serialize(feedback);
            }
            catch { }
            return StatusCode(201, dto);
        }
    }
}

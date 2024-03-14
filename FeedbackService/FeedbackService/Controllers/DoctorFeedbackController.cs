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
    public class DoctorFeedbackController : ControllerBase
    {
        private readonly IFeedbackService<DoctorFeedback> doctorFeedback;
        private readonly IMapper mapper;

        public DoctorFeedbackController(IFeedbackService<DoctorFeedback> doctorFeedback, IMapper mapper)
        {
            this.doctorFeedback = doctorFeedback;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DoctorFeedbackDTO>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<DoctorFeedback> feedback = await doctorFeedback.GetAsync();
            var DTOs = mapper.Map<List<DoctorFeedbackDTO>>(feedback);
            return Ok(DTOs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DoctorFeedbackDTO))]
        public async Task<IActionResult> Get(int id)
        {
            DoctorFeedback feedback = await doctorFeedback.GetAsync(id);

            var DTO = mapper.Map<DoctorFeedbackDTO>(feedback);
            return Ok(DTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(DoctorFeedbackDTO))]
        public async Task<IActionResult> Post(DoctorFeedbackDTO model)
        {
            DoctorFeedback feedback = mapper.Map<DoctorFeedback>(model);
            doctorFeedback.Add(feedback);
            await doctorFeedback.SaveAsync();
            var dto = mapper.Map<DoctorFeedbackDTO>(feedback);

            try
            {
                var json = JsonSerializer.Serialize(feedback);
            }
            catch { }
            return StatusCode(201, dto);
        }
    }
}

using AppointmentBillingService.DTOs;
using AppointmentBillingService.Models;
using AppointmentBillingService.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppointmentBillingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IRepository<Appointment> AppointmentRepository;

        private readonly IMapper mapper;
        public BookController(IRepository<Appointment> AppointmentRepository, IMapper mapper)
        {
            this.AppointmentRepository = AppointmentRepository;
            this.mapper = mapper;
        }
        [HttpGet("AppointmentInfo")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AppointmentDTO>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Appointment> patient = await AppointmentRepository.GetAsync();

            var DTOs = mapper.Map<List<AppointmentDTO>>(patient);
            return Ok(DTOs);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AppointmentDTO))]
        public async Task<IActionResult> Get(int id)
        {
            Appointment appointment = await AppointmentRepository.GetAsync(id);

            var DTO = mapper.Map<AppointmentDTO>(appointment);
            return Ok(DTO);
        }

        [HttpPost("Appointment")]
        [ProducesResponseType(201, Type = typeof(AppointmentDTO))]
        public async Task<IActionResult> Post(AppointmentDTO model)
        {
            Appointment appointment = mapper.Map<Appointment>(model);
            AppointmentRepository.Add(appointment);
            await AppointmentRepository.SaveAsync();
            var dto = mapper.Map<AppointmentDTO>(appointment);

            try
            {
                var json = JsonSerializer.Serialize(appointment);
            }
            catch { }
            return StatusCode(201, dto);
        }

        [HttpPut("Update")]
        [ProducesResponseType(200, Type = typeof(AppointmentDTO))]
        public async Task<IActionResult> Put(AppointmentDTO model)
        {
            Appointment appointment = mapper.Map<Appointment>(model);
            AppointmentRepository.Update(appointment);
            await AppointmentRepository.SaveAsync();
            var dto = mapper.Map<AppointmentDTO>(appointment);
            return Ok(dto);
        }
    }
}

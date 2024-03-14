using AutoMapper;
using HospitalManagementService.Models;
using HospitalManagementService.Models.DTOs;
using HospitalManagementService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository<Facility> facilityRepository;
        private readonly IMapper mapper;
        public FacilityController(IFacilityRepository<Facility> facilityRepository, IMapper mapper)
        {
            this.facilityRepository = facilityRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FacilityDTO>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Facility> facility = await facilityRepository.GetAsync();
            var DTOs = mapper.Map<List<FacilityDTO>>(facility);
            return Ok(DTOs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FacilityDTO))]
        public async Task<IActionResult> Get(int id)
        {
            Facility facility = await facilityRepository.GetAsync(id);

            var DTO = mapper.Map<FacilityDTO>(facility);
            return Ok(DTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FacilityDTO))]
        public async Task<IActionResult> Post(FacilityDTO model)
        {
            Facility facility = mapper.Map<Facility>(model);
            facilityRepository.Add(facility);
            await facilityRepository.SaveAsync();
            var dto = mapper.Map<FacilityDTO>(facility);

            try
            {
                var json = JsonSerializer.Serialize(facility);
            }
            catch { }
            return StatusCode(201, dto);
        }
    }
}

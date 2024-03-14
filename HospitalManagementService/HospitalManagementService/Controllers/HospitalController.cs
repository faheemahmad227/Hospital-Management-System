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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository<Hospital> hospitalRepository;
        private readonly IMapper mapper;
        public HospitalController(IHospitalRepository<Hospital> hospitalRepository, IMapper mapper)
        {
            this.hospitalRepository = hospitalRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HospitalDTO>))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Hospital> hospital = await hospitalRepository.GetAsync();
            //var DTOs = new List<TrainerDTO>();
            //foreach (var trainer in trainers)
            //    DTOs.Add(new TrainerDTO
            //    {
            //        Id = trainer.Id,
            //        Name = trainer.Name,
            //        Email = trainer.Email,
            //        PhoneNumber = trainer.PhoneNumber,
            //        PrimarySkill = trainer.PrimarySkill,
            //        SecondarySkills = trainer.SecondarySkills
            //    });
            var DTOs = mapper.Map<List<HospitalDTO>>(hospital);
            return Ok(DTOs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(HospitalDTO))]
        public async Task<IActionResult> Get(int id)
        {
            Hospital hospital = await hospitalRepository.GetAsync(id);

            var DTO = mapper.Map<HospitalDTO>(hospital);
            return Ok(DTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HospitalDTO))]
        public async Task<IActionResult> Post(HospitalDTO model)
        {
            Hospital hospital = mapper.Map<Hospital>(model);
            hospitalRepository.Add(hospital);
            await hospitalRepository.SaveAsync();
            var dto = mapper.Map<HospitalDTO>(hospital);

            try
            {
                var json = JsonSerializer.Serialize(hospital);
            }
            catch { }
            return StatusCode(201, dto);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(HospitalDTO))]
        public async Task<IActionResult> Put(HospitalDTO model)
        {
            Hospital hospital = mapper.Map<Hospital>(model);
            hospitalRepository.Update(hospital);
            await hospitalRepository.SaveAsync();
            var dto = mapper.Map<HospitalDTO>(hospital);
            return Ok(dto);
        }

        [HttpDelete]
        [Route("{hospitalId}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int hospitalId)
        {
            Hospital hospital = new Hospital { HospitalId = hospitalId };
            hospitalRepository.Delete(hospital);
            await hospitalRepository.SaveAsync();
            return NoContent();
        }
    }
}

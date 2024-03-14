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
    public class TestController : ControllerBase
    {
        private readonly IRepository<TestRecord> testRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public TestController(IRepository<TestRecord> testRepository, IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.testRepository = testRepository;
            this.configuration = configuration;
        }
        [HttpGet("GetTestResultDetails")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TestRecordDTO>))]
        public async Task<IActionResult> GetTestResultDetails()
        {
            IEnumerable<TestRecord> testrecord = await testRepository.GetAsync();
            var DTOs = mapper.Map<List<TestRecordDTO>>(testrecord);
            return Ok(DTOs);
        }

        [HttpPost("AddTestResults")]
        [ProducesResponseType(200, Type = typeof(TestRecordDTO))]
        public async Task<IActionResult> AddTestResults(TestRecordDTO model)
        {
            TestRecord testRecord = mapper.Map<TestRecord>(model);
            testRepository.Add(testRecord);
            await testRepository.SaveAsync();
            var dto = mapper.Map<TestRecordDTO>(testRecord);
            try
            {
                var json = JsonSerializer.Serialize(testRecord);
            }
            catch { }
            return StatusCode(200, dto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TestRecordDTO))]
        public async Task<IActionResult> Get(int id)
        {
            TestRecord testrecord = await testRepository.GetAsync(id);
            var DTO = mapper.Map<TestRecordDTO>(testrecord);
            return Ok(DTO);
        }
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(TestRecordDTO))]
        public async Task<IActionResult> Put(TestRecordDTO model)
        {
            TestRecord testrecord = mapper.Map<TestRecord>(model);
            testRepository.Update(testrecord);
            await testRepository.SaveAsync();
            var dto = mapper.Map<TestRecordDTO>(testrecord);
            return Ok(dto);
        }
    }
}

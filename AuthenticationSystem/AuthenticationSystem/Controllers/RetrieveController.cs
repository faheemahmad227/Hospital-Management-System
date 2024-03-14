using AuthenticationSystem.Models;
using AuthenticationSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrieveController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IRepository<Patient> patientsRepository;
        private readonly IRepository<Doctor> DoctorsRepository;
        private readonly IRepository<Hospital> hospitalsRepository;


        public RetrieveController(
            UserManager<ApplicationUser> userManager,
          IRepository<Patient> patientsRepository,
          IRepository<Doctor> DoctorsRepository,
          ApplicationDbContext context,
          IRepository<Hospital> hospitalsRepository)

        {
            this.userManager = userManager;
            this.context = context;
            this.patientsRepository = patientsRepository;
            this.DoctorsRepository = DoctorsRepository;
            this.hospitalsRepository = hospitalsRepository;
        }

        [HttpGet("GetDoctors")]
        public async Task<IActionResult> GetDoctors()
        {
            List<Doctor> doctor = await DoctorsRepository.GetAll("ApplicationUser");
            return Ok(doctor);
        }

        [HttpGet("GetPatients")]

        public async Task<IActionResult> GetPatients()
        {
            List<Patient> patients = await patientsRepository.GetAll("ApplicationUser");

            return Ok(patients);
        }
        [HttpGet("GetHospitals")]
        public async Task<IActionResult> GetHospitals()
        {
            List<Hospital> hospitals = await hospitalsRepository.GetAll("ApplicationUser");

            return Ok(hospitals);
        }
    }
}

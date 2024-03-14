using AuthenticationSystem.Models;
using AuthenticationSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IRepository<Patient> patientsRepository;
        private readonly IRepository<Doctor> DoctorsRepository;
        private readonly IRepository<Hospital> hospitalsRepository;

        public AuthController(UserManager<ApplicationUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IConfiguration configuration,
                              IRepository<Patient> patientsRepository,
                              IRepository<Doctor> DoctorsRepository,
                              IRepository<Hospital> hospitalsRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.patientsRepository = patientsRepository;
            this.DoctorsRepository = DoctorsRepository;
            this.hospitalsRepository = hospitalsRepository;
        }

        [HttpPost("Patientregister")]
        public async Task<IActionResult> Register(PatientRoll model)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            //IdentityUser appUser = new IdentityUser
            ApplicationUser appUser = new ApplicationUser
            {
                FullName = model.FirstName+model.LastName,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Address = model.Address,

                Gender = model.Gender,
                PhoneNumber = model.ContactNumber,
                Email = model.Email,
                PasswordHash = model.Password,
            };

            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Patient"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Patient" });

            result = await userManager.AddToRoleAsync(appUser, "Patient");
            Patient patient = new Patient();

            patient.ApplicationUser = appUser;
            patient.PatientId = model.PatientId;

            patientsRepository.Add(patient);
            await patientsRepository.SaveAsync();

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }
        [HttpPost("Doctorregister")]
        public async Task<IActionResult> Register(DoctorRoll model)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            //IdentityUser appUser = new IdentityUser
            ApplicationUser appUser = new ApplicationUser
            {
                FullName = model.FirstName + model.LastName,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Address = model.Address,

                Gender = model.Gender,
                PhoneNumber = model.ContactNumber,
                Email = model.Email,
                PasswordHash = model.Password,
                RegisteredHospitalId = model.RegisteredHospitalId,
        };

            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Doctor"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Doctor" });

            result = await userManager.AddToRoleAsync(appUser, "Doctor");
            Doctor doctor = new Doctor();

            doctor.ApplicationUser = appUser;
            doctor.DoctorId = model.DoctorId;
            doctor.Qualification = model.Qualification;
            doctor.Speciality = model.Speciality;
            doctor.Experience = model.Experience;
            doctor.DayOfAvailability = model.DayOfAvailability;
            doctor.TimeOfAvailability = model.TimeOfAvailability;

            DoctorsRepository.Add(doctor);
            await DoctorsRepository.SaveAsync();

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("Hospitalregister")]
        public async Task<IActionResult> Register(HospitalAdmin model)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            //IdentityUser appUser = new IdentityUser
            ApplicationUser appUser = new ApplicationUser
            {
                FullName = model.FirstName + model.LastName,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Address = model.Address,

                Gender = model.Gender,
                PhoneNumber = model.ContactNumber,
                Email = model.Email,
                PasswordHash = model.Password,
                RegisteredHospitalId = model.RegisteredHospitalId,
            };

            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("HospitalAdmin"))
                await roleManager.CreateAsync(new IdentityRole { Name = "HospitalAdmin" });

            result = await userManager.AddToRoleAsync(appUser, "HospitalAdmin");
            Hospital hospital = new Hospital();

            hospital.ApplicationUser = appUser;
            hospital.HospitalId = model.HospitalId;
            hospitalsRepository.Add(hospital);
            await hospitalsRepository.SaveAsync();

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            ApplicationUser appUser = await userManager.FindByNameAsync(model.UserName);

            if (appUser == null) return BadRequest("Invalid username/password");

            bool isValid = await userManager.CheckPasswordAsync(appUser, model.Password);

            if (!isValid) return BadRequest("Invalid username/password");

            string key = configuration["JwtSettings:Key"];
            string issuer = configuration["JwtSettings:Issuer"];
            string audience = configuration["JwtSettings:Audience"];
            int durationInMinutes = int.Parse(configuration["JwtSettings:DurationInMinutes"]);

            IList<Claim> userClaims = await userManager.GetClaimsAsync(appUser);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName));

            var roles = await userManager.GetRolesAsync(appUser);

            userClaims.Add(new Claim(ClaimTypes.Role, roles.First()));

            byte[] keyBytes = System.Text.Encoding.ASCII.GetBytes(key);
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(durationInMinutes),
            signingCredentials: signingCredentials,
            claims: userClaims
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(jwtSecurityToken);
            var response = new LoginResponse { jwt = token, name = appUser.UserName, role = roles.First(), firstname=appUser.FullName ,registeredhospital=appUser.RegisteredHospitalId,UserId=0};

            if(response.role == "Patient")
            {
                response.UserId = await patientsRepository.GetByUserId(appUser.Id);
            }
            if (response.role == "Doctor")
            {
                response.UserId = await DoctorsRepository.GetByUserId(appUser.Id);
            }
            if (response.role == "HospitalAdmin")
            {
                response.UserId = await hospitalsRepository.GetByUserId(appUser.Id);
            }
            return Ok(response);
        }
    }
}


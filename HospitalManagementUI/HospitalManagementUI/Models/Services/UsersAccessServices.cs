using HospitalManagementUI.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.Services
{
    public class UsersAccessServices : BaseServices
    {
        public UsersAccessServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("AuthenticationAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Doctor>> GetDoctors()
        {
            var doctor = new List<Doctor>();
            var Response = await client.GetAsync("/api/Retrieve/GetDoctors");

            Response.EnsureSuccessStatusCode();

            var Json = await Response.Content.ReadAsStringAsync();
            doctor = JsonConvert.DeserializeObject<List<Doctor>>(Json);

            return doctor;
        }

        public async Task<List<Patient>> GetPatients()
        {
            var patients = new List<Patient>();
            var Response = await client.GetAsync("/api/Retrieve/GetPatients");

            Response.EnsureSuccessStatusCode();

            var Json = await Response.Content.ReadAsStringAsync();
            patients = JsonConvert.DeserializeObject<List<Patient>>(Json);

            return patients;
        }
    }
}

using HospitalManagementUI.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.Services
{
    public class UserServices
    {
        private readonly HttpClient client;
        public UserServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("AuthenticationAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> SavePatient(PatientDTO register)
        {
            var Json = JsonConvert.SerializeObject(register);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");
            var Response = await client.PostAsync("/api/auth/PatientRegister", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> SaveDoctor(DoctorDTO register)
        {
            var Json = JsonConvert.SerializeObject(register);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");
            var Response = await client.PostAsync("/api/auth/DoctorRegister", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> SaveHospitalAdmin(HospitalAdminDTO register)
        {
            var Json = JsonConvert.SerializeObject(register);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");
            var Response = await client.PostAsync("/api/auth/HospitalRegister", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/auth/login", Content);
            Response.EnsureSuccessStatusCode();
            Json = await Response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResponseDTO>(Json);
            return result;
        }
    }
}

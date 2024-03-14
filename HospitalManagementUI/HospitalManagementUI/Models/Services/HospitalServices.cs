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
    public class HospitalServices : BaseServices
    {
        public HospitalServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("HospitalManagementAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<HospitalDTO>> GetHospitals()
        {
            var Hospitals = new List<HospitalDTO>();
            var Response = await client.GetAsync("/api/hospital");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            Hospitals = JsonConvert.DeserializeObject<List<HospitalDTO>>(Json);
            return Hospitals;
        }

        public async Task<HospitalDTO> GetHospitals(int id)
        {
            var Hospital = new HospitalDTO();
            var Response = await client.GetAsync("/api/hospital/" + id);
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            Hospital = JsonConvert.DeserializeObject<HospitalDTO>(Json);
            return Hospital;
        }

        public async Task<bool> SaveHospital(HospitalDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/hospital", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> UpdateHospital(HospitalDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PutAsync("/api/hospital", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
    }
}

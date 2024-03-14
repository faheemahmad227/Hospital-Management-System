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
    public class FacilityServices : BaseServices
    {
        public FacilityServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("HospitalManagementAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<FacilityDTO>> GetFacility()
        {
            var Facility = new List<FacilityDTO>();
            var Response = await client.GetAsync("/api/facility");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            Facility = JsonConvert.DeserializeObject<List<FacilityDTO>>(Json);
            return Facility;
        }

        public async Task<FacilityDTO> GetFacility(int id)
        {
            var Facility = new FacilityDTO();
            var Response = await client.GetAsync("/api/facility/" + id);
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            Facility = JsonConvert.DeserializeObject<FacilityDTO>(Json);
            return Facility;
        }

        public async Task<bool> SaveFacility(FacilityDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/facility", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.Created;
        }
        public async Task<bool> UpdateFacility(FacilityDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PutAsync("/api/facility", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
    }
}

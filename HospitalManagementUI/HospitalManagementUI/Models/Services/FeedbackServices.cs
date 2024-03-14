using HospitalManagementUI.Models.DTOs.FeedbackDTO;
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
    public class FeedbackServices :BaseServices
    {
        public FeedbackServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("FeedbackAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> SaveDoctorFeedback(DoctorFeedbackDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/DoctorFeedback", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.Created;
        }
        public async Task<List<DoctorFeedbackDTO>> GetDoctorFeedback()
        {
            var feedbacks = new List<DoctorFeedbackDTO>();
            var Response = await client.GetAsync("/api/DoctorFeedback");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            feedbacks = JsonConvert.DeserializeObject<List<DoctorFeedbackDTO>>(Json);
            return feedbacks;
        }
        public async Task<bool> SaveFacilityFeedback(FacilityFeedbackDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/FacilityFeedback", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.Created;
        }
        public async Task<List<FacilityFeedbackDTO>> GetFacilityFeedback()
        {
            var feedbacks = new List<FacilityFeedbackDTO>();
            var Response = await client.GetAsync("/api/FacilityFeedback/Facility");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            feedbacks = JsonConvert.DeserializeObject<List<FacilityFeedbackDTO>>(Json);
            return feedbacks;
        }
    }
}

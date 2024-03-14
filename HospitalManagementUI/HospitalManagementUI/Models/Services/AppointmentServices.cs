using HospitalManagementUI.Models.DTOs;
using HospitalManagementUI.Models.DTOs.FacilityServiceDTO;
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
    public class AppointmentServices :BaseServices
    {
        public AppointmentServices(IHttpClientFactory factory)
        {
            client = factory.CreateClient("BookingAppointmentAPI");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Appointment>> GetAppointment()
        {
            var appointments = new List<Appointment>();
            var Response = await client.GetAsync("/api/Book/AppointmentInfo");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            appointments = JsonConvert.DeserializeObject<List<Appointment>>(Json);
            return appointments;
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            var appointments = new Appointment();
            var Response = await client.GetAsync("/api/Book/" + id);
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            appointments = JsonConvert.DeserializeObject<Appointment>(Json);
            return appointments;
        }

        public async Task<bool> SaveAppointment(AppointmentDTO dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/Book/Appointment", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> UpdateAppointment(Appointment dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PutAsync("/api/Book/Update", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<List<Consultation>> GetConsultation()
        {
            var consultations = new List<Consultation>();
            var Response = await client.GetAsync("/api/Facility/Consultation");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            consultations = JsonConvert.DeserializeObject<List<Consultation>>(Json);
            return consultations;
        }
        public async Task<List<ECGService>> GetECGService()
        {
            var eCGServices = new List<ECGService>();
            var Response = await client.GetAsync("/api/Facility/ECGService");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            eCGServices = JsonConvert.DeserializeObject<List<ECGService>>(Json);
            return eCGServices;
        }
        public async Task<List<LaboratoryService>> GetLaboratoryService()
        {
            var laboratoryServices = new List<LaboratoryService>();
            var Response = await client.GetAsync("api/Facility/LaboratoryService");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            laboratoryServices = JsonConvert.DeserializeObject<List<LaboratoryService>>(Json);
            return laboratoryServices;
        }


        public async Task<List<PhysiotherapyService>> GetPhysiotherapyService()
        {
            var physiotherapyServices = new List<PhysiotherapyService>();
            var Response = await client.GetAsync("/api/Facility/PhysiotherapyService");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            physiotherapyServices = JsonConvert.DeserializeObject<List<PhysiotherapyService>>(Json);
            return physiotherapyServices;
        }

        public async Task<List<RadiologyService>> GetRadiologyService()
        {
            var radiologyServices = new List<RadiologyService>();
            var Response = await client.GetAsync("/api/Facility/RadiologyService");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            radiologyServices = JsonConvert.DeserializeObject<List<RadiologyService>>(Json);
            return radiologyServices;
        }
        public async Task<List<AmbulanceService>> GetAmbulanceService()
        {
            var ambulanceServices = new List<AmbulanceService>();
            var Response = await client.GetAsync("/api/Facility/AmbulanceService");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            ambulanceServices = JsonConvert.DeserializeObject<List<AmbulanceService>>(Json);
            return ambulanceServices;
        }

        public async Task<bool> AddFacility(AppointmentFacilitiesDTO facilities)
        {
            var Json = JsonConvert.SerializeObject(facilities);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/Facility/ChooseFacility", Content);

            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<List<AppointmentFacilities>> GetFacilityAppointment()
        {
            var appointments = new List<AppointmentFacilities>();
            var Response = await client.GetAsync("/api/Facility/FacilitiesInfo");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            appointments = JsonConvert.DeserializeObject<List<AppointmentFacilities>>(Json);
            return appointments;
        }
        public async Task<AppointmentFacilities> GetFacilityAppointment(int id)
        {
            var appointments = new AppointmentFacilities();
            var Response = await client.GetAsync("/api/Facility/" + id);
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            appointments = JsonConvert.DeserializeObject<AppointmentFacilities>(Json);
            return appointments;
        }
        public async Task<bool> UpdateFacilityAppointment(AppointmentFacilities dto)
        {
            var Json = JsonConvert.SerializeObject(dto);
            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PutAsync("/api/Facility/Update", Content);
            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<Consultation> GetConsultationById(int? consultationID)
        {
            var consultation = new Consultation();
            var Response = await client.GetAsync($"/api/Billing/GetByConsultationbyId/{consultationID}");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            consultation = JsonConvert.DeserializeObject<Consultation>(Json);
            return consultation;
        }
        public async Task<ECGService> GetECGById(int? eCGServicdId)
        {
            var eCGServices = new ECGService();
            var Response = await client.GetAsync($"/api/Billing/GetByECGServicebyId/{eCGServicdId}");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            eCGServices = JsonConvert.DeserializeObject<ECGService>(Json);
            return eCGServices;
        }
        public async Task<AmbulanceService> GetAmbulanceById(int? ambulanceId)
        {
            var ambulanceService = new AmbulanceService();
            var Response = await client.GetAsync($"/api/Billing/GetByAmbulanceServicebyId/{ambulanceId}");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            ambulanceService = JsonConvert.DeserializeObject<AmbulanceService>(Json);
            return ambulanceService;
        }
        public async Task<LaboratoryService> GetLabById(int? labId)
        {
            var laboratoryService = new LaboratoryService();
            var Response = await client.GetAsync($"/api/Billing/GetByLaboratoryServicebyId/{labId}");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            laboratoryService = JsonConvert.DeserializeObject<LaboratoryService>(Json);
            return laboratoryService;
        }
        public async Task<PhysiotherapyService> GetPhysioById(int? physioId)
        {
            var physiotherapyService = new PhysiotherapyService();
            var Response = await client.GetAsync($"/api/Billing/GetByPhysiotherapyServiceById/{physioId}");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            physiotherapyService = JsonConvert.DeserializeObject<PhysiotherapyService>(Json);
            return physiotherapyService;
        }
        public async Task<RadiologyService> GetRadioById(int? radioId)
        {
            var radiologyService = new RadiologyService();
            var Response = await client.GetAsync($"/api/Billing/GetByRadiologyServicebyId/{radioId}");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            radiologyService = JsonConvert.DeserializeObject<RadiologyService>(Json);
            return radiologyService;
        }
        public async Task<AppointmentFacilities> GetFacilityByAppontmentId(int appointmentId)
        {
            var facilities = new AppointmentFacilities();

            var response = await client.GetAsync("/api/Facility/GetByAppontmentById?id="+appointmentId);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            facilities = JsonConvert.DeserializeObject<AppointmentFacilities>(json);

            return facilities;
        }
        public async Task<bool> GenerateBill(BillingDTO billing)
        {
            var Json = JsonConvert.SerializeObject(billing);

            var Content = new StringContent(Json, Encoding.UTF8, "application/json");

            var Response = await client.PostAsync("/api/Billing/Charges", Content);

            Response.EnsureSuccessStatusCode();
            return Response.StatusCode == HttpStatusCode.OK;
        }
        public async Task<List<Billing>> GetBill()
        {
            var billings = new List<Billing>();
            var Response = await client.GetAsync("/api/Billing/GetCharges");
            Response.EnsureSuccessStatusCode();
            var Json = await Response.Content.ReadAsStringAsync();
            billings = JsonConvert.DeserializeObject<List<Billing>>(Json);
            return billings;
        }
    }
}

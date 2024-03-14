using HospitalManagementUI.Models.DTOs;
using HospitalManagementUI.Models.DTOs.FeedbackDTO;
using HospitalManagementUI.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    public class PatientController : Controller
    {
        private readonly HospitalServices hospitalService;
        private readonly FacilityServices facilityService;
        private readonly UsersAccessServices usersAccessServices;
        private readonly AppointmentServices appointmentServices;
        private readonly FeedbackServices feedbackServices;
        public int? patientId;
        public int appId;

        public PatientController(HospitalServices hospitalService, FacilityServices facilityService, UsersAccessServices usersAccessServices, AppointmentServices appointmentServices, FeedbackServices feedbackServices) : base()
        {
            this.hospitalService = hospitalService;
            this.facilityService = facilityService;
            this.usersAccessServices = usersAccessServices;
            this.appointmentServices = appointmentServices;
            this.feedbackServices = feedbackServices;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //trainerService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.FirstName = HttpContext.Session.GetString("firstname");
            var id = HttpContext.Session.GetInt32("UserId");
            patientId = id;
            var Role = HttpContext.Session.GetString("role");
            ViewBag.Role = Role;
            if (!Role.Equals("Patient"))
                context.Result = new RedirectToActionResult("Logout", "Auth", null);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListHospital()
        {
            var Hospitals = await hospitalService.GetHospitals();
            return View(Hospitals);
        }
        public async Task<IActionResult> FacilityDetails(int id)
        {
            var facility = await facilityService.GetFacility();
            var facilities = facility.Where(m => m.HospitalId == id);
            return View(facilities);
        }
        public async Task<IActionResult> DoctorDetails(int id)
        {
            var doctor = await usersAccessServices.GetDoctors();
            var doctors = doctor.Where(m => (m.ApplicationUser.RegisteredHospitalId) == id);
            return View(doctors);
        }

        public async Task<IActionResult> BookAppointment()
        {
            ViewBag.patientId = patientId;
            var Patients = await usersAccessServices.GetPatients();
            ViewBag.SelectListPatient = new SelectList(Patients.Where(id => id.PatientId == patientId), "PatientId", "ApplicationUser.FullName");
            var Hospitals = await hospitalService.GetHospitals();
            ViewBag.SelectListHospital = new SelectList(Hospitals, "HospitalId", "HospitalName");
            var Doctors = await usersAccessServices.GetDoctors();
            ViewBag.SelectListDoctor = new SelectList(Doctors, "DoctorId", "ApplicationUser.FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(AppointmentDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var IsAdded = await appointmentServices.SaveAppointment(model);
            if (IsAdded)
            {
                TempData["Success"] = "Your Appointment is booked successfully";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to Add Appointment");
            return View(model);
        }

        public async Task<IActionResult> ListAppointment()
        {
            var appointments = await appointmentServices.GetAppointment();
            var booked = appointments.Where(m => (m.PatientId) == patientId);
            return View(booked);
        }

        public async Task<IActionResult> AddFacility(int id)
        {
            var hospital = await appointmentServices.GetAppointment();
            ViewBag.SelectListHospital = new SelectList(hospital.Where(m => m.AppointmentId == id), "HospitalId", "HospitalId");
            var appointments = await appointmentServices.GetAppointment();
            ViewBag.SelectListAppointment = new SelectList(appointments.Where(x => x.AppointmentId == id), "AppointmentId", "AppointmentId");
            var consultations = await appointmentServices.GetConsultation();
            ViewBag.ConsultationList = new SelectList(consultations, "ConsultationId", "ConsultationType");
            var eCGServices = await appointmentServices.GetECGService();
            ViewBag.ECGList = new SelectList(eCGServices, "ECGServiceId", "ECGServiceType");
            var laboratoryServices = await appointmentServices.GetLaboratoryService();
            ViewBag.LabList = new SelectList(laboratoryServices, "LaboratoryServiceId", "LaboratoryType");
            var physiotherapyServices = await appointmentServices.GetPhysiotherapyService();
            ViewBag.PhysioList = new SelectList(physiotherapyServices, "PhysiotherapyServiceId", "PhysiotherapyType");
            var radiologyServices = await appointmentServices.GetRadiologyService();
            ViewBag.RadioList = new SelectList(radiologyServices, "RadiologyServiceId", "RadiologyType");
            var ambulanceService = await appointmentServices.GetAmbulanceService();
            ViewBag.AmbulanceList = new SelectList(ambulanceService, "AmbulanceServiceId", "AmbulanceType");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFacility(AppointmentFacilitiesDTO model)
        {
            //if (!ModelState.IsValid) return View(model);

            var IsAdded = await appointmentServices.AddFacility(model);
            if (IsAdded)
            {
                TempData["Success"] = "Facility Added Successfully!";
                return RedirectToAction("ListAppointment");
            }

            ModelState.AddModelError("", "Failed to Add Facility");
            return View(model);
        }

        public async Task<IActionResult> AddDoctorFeedback(int id)
        {
            var appointments = await appointmentServices.GetAppointment();
            ViewBag.SelectListDoctor = new SelectList(appointments.Where(c => c.AppointmentId == id), "DoctorId", "DoctorId");
            ViewBag.SelectListAppointment = new SelectList(appointments.Where(x => x.AppointmentId == id ), "AppointmentId", "AppointmentId");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDoctorFeedback(DoctorFeedbackDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var IsAdded = await feedbackServices.SaveDoctorFeedback(model);
            if (IsAdded)
            {
                TempData["Success"] = "Thankyou for giving your valuable Feedback";
                return RedirectToAction("ListAppointment");
            }

            ModelState.AddModelError("", "Failed to Add Feedback");
            return View(model);
        }

        public async Task<IActionResult> AddFacilityFeedback(int id)
        {
            var appointments = await appointmentServices.GetAppointment();
            ViewBag.SelectListHospital = new SelectList(appointments.Where(c => c.AppointmentId == id), "HospitalId", "HospitalId");
            ViewBag.SelectListAppointment = new SelectList(appointments.Where(x => x.AppointmentId == id), "AppointmentId", "AppointmentId");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFacilityFeedback(FacilityFeedbackDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var IsAdded = await feedbackServices.SaveFacilityFeedback(model);
            if (IsAdded)
            {
                TempData["Success"] = "Thankyou for giving your valuable Feedback";
                return RedirectToAction("ListAppointment");
            }

            ModelState.AddModelError("", "Failed to Add Feedback");
            return View(model);
        }
        public async Task<IActionResult> ListFacilityAppointment(int id)
        {
            var appointments = await appointmentServices.GetFacilityAppointment();
            var booked = appointments.Where(m => (m.AppointmentId) == id);
            return View(booked);
        }
        public async Task<IActionResult> BillDetail()
        {
            var appointments = await appointmentServices.GetAppointment();
            int booked = appointments.Where(m => (m.PatientId) == patientId).Select(m => m.AppointmentId).First();
            var billing = await appointmentServices.GetBill();
            var bill = billing.Where(x => x.AppointmentId == booked);
            return View(bill);
        }
    }
}

using HospitalManagementUI.Models.DTOs;
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
    public class HospitalAdminController : Controller
    {
        private readonly HospitalServices hospitalService;
        private readonly FacilityServices facilityService;
        private readonly FeedbackServices feedbackServices;
        private readonly AppointmentServices appointmentServices;
        public int? hospitalid;

        public HospitalAdminController(HospitalServices hospitalService, FacilityServices facilityService, FeedbackServices feedbackServices, AppointmentServices appointmentServices) : base()
        {
            this.hospitalService = hospitalService;
            this.facilityService = facilityService;
            this.feedbackServices = feedbackServices;
            this.appointmentServices = appointmentServices;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //trainerService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.FirstName = HttpContext.Session.GetString("firstname");
            var id = HttpContext.Session.GetInt32("registeredhospital");
            hospitalid = id;
            var Role = HttpContext.Session.GetString("role");
            ViewBag.Role = Role;
            if (!Role.Equals("HospitalAdmin"))
                context.Result = new RedirectToActionResult("Logout", "Auth", null);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListFacility()
        {
            ViewBag.id = hospitalid;
            var Facility = await facilityService.GetFacility();
            return View(Facility);
        }

        public async Task<IActionResult> CreateFacility()
        {
            var Hospitals =  await hospitalService.GetHospitals();
            ViewBag.SelectListHospital = new SelectList(Hospitals.Where(id => id.HospitalId==hospitalid), "HospitalId", "HospitalName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFacility(FacilityDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var IsAdded = await facilityService.SaveFacility(model);
            if (IsAdded)
            {
                TempData["Success"] = "Facility Added Successfully!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to Add Facility");
            return View(model);
        }
        public async Task<IActionResult> FacilityDetails(int id)
        {
            var Facilitydto = await facilityService.GetFacility(id);
            if (Facilitydto == null) return NotFound();
            return View(Facilitydto);
        }

        public async Task<IActionResult> FacilityEdit(int id)
        {
            var Facilitydto = await facilityService.GetFacility(id);
            if (Facilitydto == null) return NotFound();
            return View(Facilitydto);
        }

        [HttpPost]
        public async Task<IActionResult> FacilityEdit(FacilityDTO model)
        {
            if (!ModelState.IsValid) return View(model);
            var IsUpdated = await facilityService.UpdateFacility(model);
            if (IsUpdated)
            {
                TempData["Updated"] = "Facility Data is Saved Successfully!";
                return RedirectToAction("ListFacility");
            }
            ModelState.AddModelError("", "Failed to Save Facility");
            return View(model);
        }
        public async Task<IActionResult> ListFeedback()
        {
            var feedback = await feedbackServices.GetFacilityFeedback();
            var feedbacks = feedback.Where(x => x.HospitalId == hospitalid);
            return View(feedbacks);
        }

        public async Task<IActionResult> AppointmentList()
        {
            var booking = await appointmentServices.GetFacilityAppointment();
            var facility = booking.Where(x => x.HospitalId == hospitalid);
            return View(facility);
        }

        public async Task<IActionResult> AppointmentEdit(int id)
        {
            var appointment = await appointmentServices.GetFacilityAppointment(id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> AppointmentEdit(AppointmentFacilities model)
        {
           // if (!ModelState.IsValid) return View(model);
            var IsUpdated = await appointmentServices.UpdateFacilityAppointment(model);
            if (IsUpdated)
            {
                TempData["Success"] = "Patient Facility Appointment is Confirmed Successfully!";
                return RedirectToAction("AppointmentList");
            }
            ModelState.AddModelError("", "Failed to Save Appointment");
            return View(model);
        }
        public async Task<IActionResult> AppointmentFacilityList()
        {
            var booking = await appointmentServices.GetFacilityAppointment();
            var facility = booking.Where(x => x.HospitalId == hospitalid);
            return View(facility);
        }

        public async Task<IActionResult> GenerateBill(int id)
        {
            var appointments = await appointmentServices.GetAppointment();
            ViewBag.SelectListHospital = new SelectList(appointments.Where(c => c.AppointmentId == id), "HospitalId", "HospitalId");
            ViewBag.Id = id;
            int amb=0, con=0, ecg=0, lab=0, phy=0, rad=0;

            var facility = await appointmentServices.GetFacilityByAppontmentId(id);

            var ambulanceServiceId = facility.AmbulanceServiceId;
            var consultationId = facility.ConsultationId;
            var eCGServiceId = facility.ECGServiceId;
            var laboratoryServiceId = facility.PhysiotherapyServiceId;
            var physiotherapyServiceId = facility.ConsultationId;
            var radiologyServiceId = facility.RadiologyServiceId;

            ViewBag.AmbulanceCharge = 0;
            ViewBag.ConsultationCharge = 0;
            ViewBag.eCGCharge = 0;
            ViewBag.LabCharge = 0;
            ViewBag.PhysioCharge = 0;
            ViewBag.RadioCharge = 0;

            if (ambulanceServiceId != null)
            { 
                var ambulance = await appointmentServices.GetAmbulanceById(ambulanceServiceId);
                amb = ambulance.Charge;
                ViewBag.AmbulanceCharge = amb;
            }
            if (consultationId != null)
            {
                var consultation = await appointmentServices.GetConsultationById(consultationId);
                con = consultation.Charge;
                ViewBag.ConsultationCharge = con;
            }
            if (eCGServiceId != null)
            {
                var eCG = await appointmentServices.GetECGById(eCGServiceId);
                ecg = eCG.Charge;
                ViewBag.eCGCharge = ecg;
            }
            if (laboratoryServiceId != null)
            {
                var laboratory = await appointmentServices.GetLabById(laboratoryServiceId);
                lab = laboratory.Charge;
                ViewBag.LabCharge = lab;
            }
            if (physiotherapyServiceId != null)
            { 
                var physio = await appointmentServices.GetPhysioById(physiotherapyServiceId);
                phy = physio.Charge;
                ViewBag.PhysioCharge = phy;
            }
            if (radiologyServiceId != null)
            {
                var radio = await appointmentServices.GetRadioById(radiologyServiceId);
                rad = radio.Charge;
                ViewBag.RadioCharge = rad;
            }

            var total = amb+con+ecg+lab+phy+rad;
            ViewBag.totalCharge = total;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateBill(BillingDTO billing)
        {
            int amb = 0, con = 0, ecg = 0, lab = 0, phy = 0, rad = 0;
            var facility = await appointmentServices.GetFacilityByAppontmentId(billing.AppointmentId);

            var ambulanceServiceId = facility.AmbulanceServiceId;
            var consultationId = facility.ConsultationId;
            var eCGServiceId = facility.ECGServiceId;
            var laboratoryServiceId = facility.PhysiotherapyServiceId;
            var physiotherapyServiceId = facility.ConsultationId;
            var radiologyServiceId = facility.RadiologyServiceId;
            if (ambulanceServiceId != null)
            {
                var ambulance = await appointmentServices.GetAmbulanceById(ambulanceServiceId);
                amb = ambulance.Charge;
                billing.AmbulanceServiceCharge = amb;
            }
            if (consultationId != null)
            {
                var consultation = await appointmentServices.GetConsultationById(consultationId);
                con = consultation.Charge;
                billing.ConsultationsCharge = con;
            }
            if (eCGServiceId != null)
            {
                var eCG = await appointmentServices.GetECGById(eCGServiceId);
                ecg = eCG.Charge;
                billing.ECGServiceCharge = ecg;
            }
            if (laboratoryServiceId != null)
            {
                var laboratory = await appointmentServices.GetLabById(laboratoryServiceId);
                lab = laboratory.Charge;
                billing.LaboratoryServiceCharge = lab;
            }
            if (physiotherapyServiceId != null)
            {
                var physio = await appointmentServices.GetPhysioById(physiotherapyServiceId);
                phy = physio.Charge;
                billing.PhysiotherapyServiceCharge = phy;
            }
            if (radiologyServiceId != null)
            {
                var radio = await appointmentServices.GetRadioById(radiologyServiceId);
                rad = radio.Charge;
                billing.RadiologyServiceCharge = rad;
            }

            billing.TotalAmount = amb + con + ecg + lab + phy + rad;

            await appointmentServices.GenerateBill(billing);

            return RedirectToAction("AppointmentFacilityList");
        }
        public async Task<IActionResult> BillDetail()
        {
            var billing = await appointmentServices.GetBill();
            var bill = billing.Where(x => x.HospitalId == hospitalid);
            return View(bill);
        }
    }
}

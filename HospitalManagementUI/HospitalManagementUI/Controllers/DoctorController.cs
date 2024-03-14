using HospitalManagementUI.Models.DTOs;
using HospitalManagementUI.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    public class DoctorController : Controller
    {
        private readonly AppointmentServices appointmentServices;
        private readonly FeedbackServices feedbackServices;
        public int? doctorId;
        public DoctorController(AppointmentServices appointmentServices, FeedbackServices feedbackServices) : base()
        {
            this.appointmentServices = appointmentServices;
            this.feedbackServices = feedbackServices;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //trainerService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.FirstName = HttpContext.Session.GetString("firstname");
            var id = HttpContext.Session.GetInt32("UserId");
            doctorId = id;
            var Role = HttpContext.Session.GetString("role");
            ViewBag.Role = Role;
            if (!Role.Equals("Doctor"))
                context.Result = new RedirectToActionResult("Logout", "Auth", null);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AppointmentList()
        {
            var booking = await appointmentServices.GetAppointment();
            var appointment = booking.Where(m => m.DoctorId == doctorId);
            return View(appointment);
        }

        public async Task<IActionResult> AppointmentEdit(int id)
        {
            var appointment = await appointmentServices.GetAppointment(id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> AppointmentEdit(Appointment model)
        {
            if (!ModelState.IsValid) return View(model);
            var IsUpdated = await appointmentServices.UpdateAppointment(model);
            if (IsUpdated)
            {
                TempData["Success"] = "Patient Appointment is Confirmed Successfully!";
                return RedirectToAction("AppointmentList");
            }
            ModelState.AddModelError("", "Failed to Save Appointment");
            return View(model);
        }
        public async Task<IActionResult> ListFeedback()
        {
            var feedback = await feedbackServices.GetDoctorFeedback();
            var feedbacks = feedback.Where(x => x.DoctorId == doctorId);
            return View(feedbacks);
        }
    }
}

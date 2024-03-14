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
    public class SystemAdminController : Controller
    {
        private readonly HospitalServices hospitalService;

        public SystemAdminController(HospitalServices hospitalService) : base()
        {
            this.hospitalService = hospitalService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //trainerService.SetBearerToken(HttpContext.Session.GetString("token"));
            ViewBag.FirstName = HttpContext.Session.GetString("firstname");
            var Role = HttpContext.Session.GetString("role");
            ViewBag.Role = Role;
            if (!Role.Equals("SystemAdmin"))
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

        public IActionResult CreateHospital()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHospital(HospitalDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var IsAdded = await hospitalService.SaveHospital(model);
            if (IsAdded)
            {
                TempData["Success"] = "Hospital Added Successfully!";
                return RedirectToAction("ListHospital");
            }

            ModelState.AddModelError("", "Failed to Add Hospital");
            return View(model);
        }

        public async Task<IActionResult> HospitalDetails(int id)
        {
            var Hospitaldto = await hospitalService.GetHospitals(id);
            if (Hospitaldto == null) return NotFound();
            return View(Hospitaldto);
        }

        public async Task<IActionResult> HospitalEdit(int id)
        {
            var Hospitaldto = await hospitalService.GetHospitals(id);
            if (Hospitaldto == null) return NotFound();
            return View(Hospitaldto);
        }

        [HttpPost]
        public async Task<IActionResult> HospitalEdit(HospitalDTO model)
        {
            if (!ModelState.IsValid) return View(model);
            var IsUpdated = await hospitalService.UpdateHospital(model);
            if (IsUpdated)
            {
                TempData["Updated"] = "Hopsital Data is Saved Successfully!";
                return RedirectToAction("ListHospital");
            }
                ModelState.AddModelError("", "Failed to Save Hospital");
            return View(model);
        }
    }
}

using HospitalManagementUI.Models.DTOs;
using HospitalManagementUI.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserServices userServices;
        private readonly HospitalServices hospitalService;

        public AuthController(UserServices userServices, HospitalServices hospitalService)
        {
            this.userServices = userServices;
            this.hospitalService = hospitalService;
        }
        public IActionResult PatientRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PatientRegister(PatientDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await userServices.SavePatient(model);
            if (IsAdded)
            {
                TempData["Success"] = "Your Registeration is Successful!";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Registeration Failed");
            return View(model);
        }
        public async Task<IActionResult> DoctorRegister()
        {
            var Hospitals = await hospitalService.GetHospitals();
            ViewBag.SelectListHospital = new SelectList(Hospitals, "HospitalId", "HospitalName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DoctorRegister(DoctorDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await userServices.SaveDoctor(model);
            if (IsAdded)
            {
                TempData["Success"] = "Your Registeration is Successful!";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Registeration Failed");
            return View(model);
        }
        public async Task<IActionResult> HospitalAdminRegister()
        {
            var Hospitals = await hospitalService.GetHospitals();
            ViewBag.SelectListHospital = new SelectList(Hospitals, "HospitalId", "HospitalName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HospitalAdminRegister(HospitalAdminDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var IsAdded = await userServices.SaveHospitalAdmin(model);
            if (IsAdded)
            {
                TempData["Success"] = "Your Registeration is Successful!";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Registeration Failed");
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO model)
        {
            if (!ModelState.IsValid) return View(model);

            var Result = await userServices.Login(model);

            HttpContext.Session.SetString("token", Result.jwt);
            HttpContext.Session.SetString("name", Result.name);
            HttpContext.Session.SetString("role", Result.role);
            HttpContext.Session.SetString("firstname", Result.firstname);
            HttpContext.Session.SetInt32("registeredhospital", Result.registeredhospital);
            HttpContext.Session.SetInt32("UserId", Result.UserId);

            if (Result.role.Equals("HospitalAdmin"))
                return RedirectToAction("Index", "HospitalAdmin");
            else if (Result.role.Equals("Doctor"))
                return RedirectToAction("Index", "Doctor");
            else if (Result.role.Equals("Patient"))
                return RedirectToAction("Index", "Patient");
            else if (Result.role.Equals("SystemAdmin"))
                return RedirectToAction("Index", "SystemAdmin");
            ModelState.AddModelError("", "Cannot identify the user");
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Logoff"] = "You Logged Out Successfully!";
            return RedirectToAction("Login");
        }
    }
}

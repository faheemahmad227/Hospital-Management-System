using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class AppointmentFacilities
    {
        [Key]
        public int FacilityAppointmentId { get; set; }
        [Display(Name = "Appointment Id")]
        public int AppointmentId { get; set; }
        [Display(Name = "Hospital Id")]
        public int HospitalId { get; set; }
        [Display(Name = "Consultation")]
        public int? ConsultationId { get; set; }
        [Display(Name = "Physiotherapy")]
        public int? PhysiotherapyServiceId { get; set; }
        [Display(Name = "Laboratory")]
        public int? LaboratoryServiceId { get; set; }
        [Display(Name = "ECG Test")]
        public int? ECGServiceId { get; set; }
        [Display(Name = "Radiology Test")]
        public int? RadiologyServiceId { get; set; }
        [Display(Name = "Ambulance Service")]
        public int? AmbulanceServiceId { get; set; }
        public string Status { get; set; }
    }
}

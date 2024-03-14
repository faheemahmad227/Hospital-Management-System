using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class AppointmentDTO
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required, Display(Name ="Hospital Name")]

        public int HospitalId { get; set; }

        [Required, Display(Name = "Patient Name")]
        public int PatientId { get; set; }
        [Display(Name = "Doctor Name")]
        public int DoctorId { get; set; }

        public string Remarks { get; set; }
        [Required]
        public DateTime DateOfAppointment { get; set; }
        [Display(Name = "Medical History")]
        public string MedicalHistory { get; set; }
    }
}

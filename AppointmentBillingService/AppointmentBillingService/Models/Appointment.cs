using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int HospitalId { get; set; }

        [Required]
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Remarks { get; set; }
        [Required]
        public DateTime DateOfAppointment { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";
        public string MedicalHistory { get; set; }
    }
}

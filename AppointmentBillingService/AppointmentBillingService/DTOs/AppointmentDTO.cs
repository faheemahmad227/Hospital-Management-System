using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        public int HospitalId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Remarks { get; set; }

        public DateTime DateOfAppointment { get; set; }

        public string Status { get; set; } = "Pending";
        public string MedicalHistory { get; set; }

    }
}

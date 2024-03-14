using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class Billing
    {
        [Key]
        public int BillingId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int HospitalId { get; set; }
        public int ConsultationsCharge { get; set; }
        public int LaboratoryServiceCharge { get; set; }
        public int PhysiotherapyServiceCharge { get; set; }
        public int ECGServiceCharge { get; set; }
        public int RadiologyServiceCharge { get; set; }
        public int AmbulanceServiceCharge { get; set; }
        public int TotalAmount { get; set; }
        [Required]
        public string PaymentStatus { get; set; } = "Pending";
    }
}

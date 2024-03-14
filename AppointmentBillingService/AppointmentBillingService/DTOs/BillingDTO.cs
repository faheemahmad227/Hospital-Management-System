using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class BillingDTO
    {
        public int BillingId { get; set; }
        public int AppointmentId { get; set; }
        public int HospitalId { get; set; }

        public int ConsultationsCharge { get; set; }
        public int LaboratoryServiceCharge { get; set; }
        public int PhysiotherapyServiceCharge { get; set; }
        public int ECGServiceCharge { get; set; }
        public int RadiologyServiceCharge { get; set; }
        public int AmbulanceServiceCharge { get; set; }
        public int TotalAmount { get; set; }

        public string PaymentStatus { get; set; } = "Pending";
    }
}

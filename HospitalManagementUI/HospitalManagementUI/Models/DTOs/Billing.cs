using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class Billing
    {
        public int BillingId { get; set; }
        [Display(Name="Appointment Id")]
        public int AppointmentId { get; set; }
        public int HospitalId { get; set; }
        [Display(Name = "Consultation Fee")]

        public int ConsultationsCharge { get; set; }
        [Display(Name = "Laboratory Fee")]
        public int LaboratoryServiceCharge { get; set; }
        [Display(Name = "Physiotherapy Fee")]
        public int PhysiotherapyServiceCharge { get; set; }
        [Display(Name = "ECGService Fee")]
        public int ECGServiceCharge { get; set; }
        [Display(Name = "Radiology Fee")]
        public int RadiologyServiceCharge { get; set; }
        [Display(Name = "Ambulance Fee")]
        public int AmbulanceServiceCharge { get; set; }
        [Display(Name = "Total Amount")]
        public int TotalAmount { get; set; }
        [Display(Name = "Payment Status")]

        public string PaymentStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class Consultation
    {
        [Key]
        public int ConsultationId { get; set; }
        public string ConsultationType { get; set; }
        public int Charge { get; set; }
    }
}

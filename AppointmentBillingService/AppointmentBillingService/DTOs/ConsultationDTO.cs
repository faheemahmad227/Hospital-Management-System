using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class ConsultationDTO
    {
        public int ConsultationId { get; set; }
        public string ConsultationType { get; set; }
        public int Charge { get; set; }
    }
}

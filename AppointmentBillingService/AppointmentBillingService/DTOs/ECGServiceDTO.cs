using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class ECGServiceDTO
    {
        public int ECGServiceId { get; set; }
        public int Charge { get; set; }
        public string ECGServiceType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class AmbulanceServiceDTO
    {
        public int AmbulanceServiceId { get; set; }
        public int Charge { get; set; }
        public string AmbulanceType { get; set; }
    }
}

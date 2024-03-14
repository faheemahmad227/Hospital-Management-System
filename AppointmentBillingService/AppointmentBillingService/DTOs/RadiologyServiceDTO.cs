using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class RadiologyServiceDTO
    {
        public int RadiologyServiceId { get; set; }
        public int Charge { get; set; }
        public string RadiologyType { get; set; }
    }
}

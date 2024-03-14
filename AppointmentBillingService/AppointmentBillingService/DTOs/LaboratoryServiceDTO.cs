using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class LaboratoryServiceDTO
    {
        public int LaboratoryServiceId { get; set; }
        public string LaboratoryType { get; set; }
        public int Charge { get; set; }
    }
}

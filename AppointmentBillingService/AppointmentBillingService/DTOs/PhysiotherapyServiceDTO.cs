using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.DTOs
{
    public class PhysiotherapyServiceDTO
    {
        public int PhysiotherapyServiceId { get; set; }
        public int Charge { get; set; }
        public string PhysiotherapyType { get; set; }
    }
}

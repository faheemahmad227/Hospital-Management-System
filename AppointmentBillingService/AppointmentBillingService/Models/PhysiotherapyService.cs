using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class PhysiotherapyService
    {
        [Key]
        public int PhysiotherapyServiceId { get; set; }
        public int Charge { get; set; }
        public string PhysiotherapyType { get; set; }
    }
}

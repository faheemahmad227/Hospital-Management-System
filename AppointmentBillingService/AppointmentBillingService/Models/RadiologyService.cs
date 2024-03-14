using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class RadiologyService
    {
        [Key]
        public int RadiologyServiceId { get; set; }
        public int Charge { get; set; }
        public string RadiologyType { get; set; }
    }
}

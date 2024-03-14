using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class AmbulanceService
    {
        [Key]
        public int AmbulanceServiceId { get; set; }
        public int Charge { get; set; }
        public string AmbulanceType { get; set; }
    }
}

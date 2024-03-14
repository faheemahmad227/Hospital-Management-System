using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class ECGService
    {
        [Key]
        public int ECGServiceId { get; set; }
        public int Charge { get; set; }
        public string ECGServiceType { get; set; }
    }
}

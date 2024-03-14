using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class LaboratoryService
    {
        [Key]
        public int LaboratoryServiceId { get; set; }
        public string LaboratoryType { get; set; }
        public int Charge { get; set; }
    }
}

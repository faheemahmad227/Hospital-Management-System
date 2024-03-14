using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs.FacilityServiceDTO
{
    public class AmbulanceService
    {
        public int AmbulanceServiceId { get; set; }
        public int Charge { get; set; }
        public string AmbulanceType { get; set; }
    }
}

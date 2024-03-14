using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs.FacilityServiceDTO
{
    public class RadiologyService
    {
        public int RadiologyServiceId { get; set; }
        public int Charge { get; set; }
        public string RadiologyType { get; set; }
    }
}

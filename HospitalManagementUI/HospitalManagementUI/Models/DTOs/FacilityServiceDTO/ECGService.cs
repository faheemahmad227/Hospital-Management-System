using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs.FacilityServiceDTO
{
    public class ECGService
    {
        public int ECGServiceId { get; set; }
        public int Charge { get; set; }
        public string ECGServiceType { get; set; }
    }
}

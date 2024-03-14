using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs.FacilityServiceDTO
{
    public class LaboratoryService
    {
        public int LaboratoryServiceId { get; set; }
        public string LaboratoryType { get; set; }

        public int Charge { get; set; }
    }
}

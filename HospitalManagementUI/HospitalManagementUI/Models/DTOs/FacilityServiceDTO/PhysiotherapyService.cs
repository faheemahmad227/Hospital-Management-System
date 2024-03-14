using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs.FacilityServiceDTO
{
    public class PhysiotherapyService
    {
        public int PhysiotherapyServiceId { get; set; }
        public int Charge { get; set; }
        public string PhysiotherapyType { get; set; }
    }
}

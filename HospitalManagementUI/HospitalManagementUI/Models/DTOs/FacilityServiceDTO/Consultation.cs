using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs.FacilityServiceDTO
{
    public class Consultation
    {
        public int ConsultationId { get; set; }
        public string ConsultationType { get; set; }

        public int Charge { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class AppointmentFacilitiesDTO
    {
        [Key]
        public int FacilityAppointmentId { get; set; }

        public int AppointmentId { get; set; }
        public int HospitalId { get; set; }
        public int? ConsultationId { get; set; } = null;

        public int? PhysiotherapyServiceId { get; set; } = null;
        public int? LaboratoryServiceId { get; set; } = null;
        public int? ECGServiceId { get; set; } = null;
        public int? RadiologyServiceId { get; set; } = null;
        public int? AmbulanceServiceId { get; set; } = null;
    }
}

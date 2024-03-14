using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs.FeedbackDTO
{
    public class FacilityFeedbackDTO
    {
        [Key]
        public int FeedbackId { get; set; }
        [Display(Name = "Appointment Id")]
        public int AppointmentId { get; set; }
        [Display(Name = "Hospital Id")]
        public int HospitalId { get; set; }
        [Display(Name = "Facilities Feedback")]
        public string FacilitiesFeedback { get; set; }
    }
}

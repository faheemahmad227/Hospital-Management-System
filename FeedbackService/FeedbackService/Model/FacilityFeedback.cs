using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackService.Model
{
    public class FacilityFeedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public int AppointmentId { get; set; }
        public int HospitalId { get; set; }

        public string FacilitiesFeedback { get; set; }
    }
}

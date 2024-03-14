using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackService.Model
{
    public class DoctorFeedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }

        public string DoctorsFeedback { get; set; }
    }
}

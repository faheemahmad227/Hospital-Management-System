using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackService.Model.DTO
{
    public class DoctorFeedbackDTO
    {
        [Key]
        public int FeedbackId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }

        public string DoctorsFeedback { get; set; }
    }
}

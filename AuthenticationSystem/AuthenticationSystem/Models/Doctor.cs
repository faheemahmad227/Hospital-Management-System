using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string DayOfAvailability { get; set; }
        [Required]
        public string TimeOfAvailability { get; set; }
        [Required]
        public int RegisteredHospitalId { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string status { get; set; } = "Unapproved";

    }
}

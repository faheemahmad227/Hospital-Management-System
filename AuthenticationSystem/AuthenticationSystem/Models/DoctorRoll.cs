using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSystem.Models
{
    public class DoctorRoll
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public string  Experience { get; set; }
        [Required]
        public string DayOfAvailability { get; set; }
        [Required]
        public string TimeOfAvailability { get; set; }

        [Required(ErrorMessage = " firstName within in range")]
        [MaxLength(50)]
        [MinLength(4)]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required]
        [Range(18, int.MaxValue, ErrorMessage = "Age shouldn't be less than 18")]

        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = " Gender should be selected")]
        public string Gender { get; set; }
        [MaxLength(10)]
        [Required(ErrorMessage = "Contact number should be 10 digits")]
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        [Required]
        public int RegisteredHospitalId { get; set; }

        [Required(ErrorMessage = "Password should be minimum 6 letters with special character included")]
        [MinLength(6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password should be minimum 6 letters with special character included")]
        [MinLength(6)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

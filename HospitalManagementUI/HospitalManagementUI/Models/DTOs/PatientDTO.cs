using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class PatientDTO
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = " FirstName within in range")]
        [MaxLength(50)]
        [MinLength(4), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Range(18, int.MaxValue, ErrorMessage = "Age shouldn't be less than 18")]

        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = " Gender should be selected")]
        public string Gender { get; set; }
        [MaxLength(10), Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Contact number should be 10 digits")]
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Password should be minimum 6 letters with special character included")]
        [MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password should be minimum 6 letters with special character included")]
        [MinLength(6), DataType(DataType.Password)]
        [Compare("Password"), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}

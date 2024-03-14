using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class HospitalDTO
    {
        public int HospitalId { get; set; }

        [Required]
        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }

        [Required]
        [Display(Name = "Hospital Address")]
        public string HospitalAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Display(Name = "Hospital Phone")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string HospitalPhone { get; set; }

        [Required]
        [Display(Name = "Hospital Website")]
        public string HospitalWebsite { get; set; }

        [Required]
        [Display(Name = "Hospital Fax No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string HospitalFax { get; set; }
    }
}

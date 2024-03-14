using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class FacilityDTO
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Hospital Name")]
        public int HospitalId { get; set; }

        [Required]
        [Display(Name = "Facility Name")]
        public string FacilityName { get; set; }

        [Display(Name = "Facility Description")]
        public string FacilityDescription { get; set; }
    }
}

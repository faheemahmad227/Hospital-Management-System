using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementService.Models.DTOs
{
    public class FacilityDTO
    {
        [Key]
        public int Id { get; set; }
        public int HospitalId { get; set; }
        [Required]
        [Display(Name = "Choose Facility")]
        public string FacilityName { get; set; }
        [Display(Name = "Facility Description")]
        public string FacilityDescription { get; set; }
    }
}

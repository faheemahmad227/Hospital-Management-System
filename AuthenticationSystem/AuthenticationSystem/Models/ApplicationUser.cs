using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage =" firstName within in range")]
        [MaxLength(50)]
        [MinLength(4)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [Range(18,int.MaxValue,ErrorMessage ="Age shouldn't be less than 18")]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = " Gender should be selected")]
        public string Gender { get; set; }
        [MaxLength(10)]
        [Required]
        public string Email { get; set; }
        public int RegisteredHospitalId { get; set; }
        public string FullName { get; set; }
    }
}

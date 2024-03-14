using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementUI.Models.DTOs
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public int registeredhospital { get; set;}
        public string firstname { get; set; }
        public string jwt { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }
}

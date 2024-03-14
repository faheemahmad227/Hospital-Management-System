using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementService.Models
{
    public class Facility
    {
        private int hospitalId;
        
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityDescription { get; set; }

        public Facility(int Id, string facilityName, string facilityDescription)
        {

            if (string.IsNullOrEmpty(facilityName))
                throw new ArgumentException($"Invalid value for : ${nameof(facilityName)}");




            if (string.IsNullOrEmpty(facilityDescription))
                throw new ArgumentException($"Invalid value for : ${nameof(facilityDescription)}");



            this.HospitalId = hospitalId;
            this.FacilityName = facilityName;
            this.FacilityDescription = facilityDescription;
        }
    }
}

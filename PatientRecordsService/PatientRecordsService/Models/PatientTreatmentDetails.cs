using System.ComponentModel.DataAnnotations;

namespace PatientRecordsService.Models
{
    public class PatientTreatmentDetails
    {
        [Key]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string Observations { get; set; }
        public string Treatment { get; set; }
        public string Recommendations { get; set; }
        public string Prescriptions { get; set; }
    }
}

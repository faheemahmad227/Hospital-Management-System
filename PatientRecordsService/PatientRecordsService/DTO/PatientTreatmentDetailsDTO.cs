using System.ComponentModel.DataAnnotations;

namespace PatientRecordsService.DTO
{
    public class PatientTreatmentDetailsDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide the required field")]
        public int AppointmentId { get; set; }
        [Required(ErrorMessage = "Please provide the required field")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please provide the required field")]
        public string Observations { get; set; }
        [Required(ErrorMessage = "Please provide the required field")]
        public string Treatment { get; set; }
        public string Recommendations { get; set; }
        public string Prescriptions { get; set; }
    }
}

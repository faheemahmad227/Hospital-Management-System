using System.ComponentModel.DataAnnotations;

namespace PatientRecordsService.DTO
{
    public class TestRecordDTO
    {
        [Key]
        public int TestId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Required]
        [Display(Name = "Choose the name of the test")]
        public string TestType { get; set; }
    }
}

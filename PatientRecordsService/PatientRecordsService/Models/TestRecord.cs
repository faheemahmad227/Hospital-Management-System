using System.ComponentModel.DataAnnotations;

namespace PatientRecordsService.Models
{
    public class TestRecord
    {
        [Key]

        public int TestId { get; set; }

        public int PatientId { get; set; }

        public string TestType { get; set; }

        public string Remarks { get; set; }
    }
}

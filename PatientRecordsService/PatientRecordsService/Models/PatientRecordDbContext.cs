using Microsoft.EntityFrameworkCore;

namespace PatientRecordsService.Models
{
    public class PatientRecordDbContext  :DbContext
    {
        public PatientRecordDbContext(DbContextOptions<PatientRecordDbContext> options) : base(options)
        {

        }

        public virtual DbSet<PatientTreatmentDetails> PatientTreatmentDetails { get; set; }
        public virtual DbSet<TestRecord> TestRecords { get; set; }
    }
}

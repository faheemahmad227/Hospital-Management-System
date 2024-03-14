using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackService.Model
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options) : base(options)
        {
        }

        public virtual DbSet<DoctorFeedback> DoctorFeedbacks { get; set; }
        public virtual DbSet<FacilityFeedback> FacilityFeedbacks { get; set; }   
    }
}

using HospitalManagementService.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementService.Models
{
    public class HospitalManagementContext : DbContext
    {
        public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options) : base(options)
        {
        }

        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
    }
}

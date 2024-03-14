using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBillingService.Models
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Appointment> DoctorAppointments { get; set; }
        public virtual DbSet<FacilityAppointment> FacilityAppointments { get; set; }
        public virtual DbSet<AmbulanceService> AmbulanceServices { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<ECGService> ECGServices { get; set; }
        public virtual DbSet<LaboratoryService> LaboratoryServices { get; set; }
        public virtual DbSet<PhysiotherapyService> PhysiotherapyServices { get; set; }
        public virtual DbSet<RadiologyService> RadiologyService { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelsBuilder)
        {
            modelsBuilder.Entity<PhysiotherapyService>().HasData(

               new PhysiotherapyService
               {

                   PhysiotherapyServiceId = 1,
                   PhysiotherapyType = "Sports Physiotherapy",
                   Charge = 1000


               },
              new PhysiotherapyService
              {
                  PhysiotherapyServiceId = 2,
                  PhysiotherapyType = "Pain Management",
                  Charge = 2000
              },

              new PhysiotherapyService
              {
                  PhysiotherapyServiceId = 3,
                  PhysiotherapyType = "Neurological physiotherapy",
                  Charge = 3000
              }


              );

            modelsBuilder.Entity<AmbulanceService>().HasData(

           new AmbulanceService
           {
               AmbulanceServiceId = 1,
               AmbulanceType = "Air Ambulance",
               Charge = 2000


           },
           new AmbulanceService
           {
               AmbulanceServiceId = 2,
               AmbulanceType = "Life Support Ambulance",
               Charge = 1000


           },
             new AmbulanceService
             {
                 AmbulanceServiceId = 3,
                 AmbulanceType = "Isolation Ambulance",
                 Charge = 3000


             }


             );

            modelsBuilder.Entity<Consultation>().HasData(
                new Consultation
                {
                    ConsultationId = 1,
                    ConsultationType = "Dermatology",

                    Charge = 500


                },
            new Consultation
            {
                ConsultationId = 2,
                ConsultationType = "General Medicine",


                Charge = 400
            },
            new Consultation
            {
                ConsultationId = 3,
                ConsultationType = "Gynaecology",

                Charge = 450
            },
            new Consultation
            {
                ConsultationId = 4,
                ConsultationType = "Neurology",


                Charge = 600
            },
            new Consultation
            {
                ConsultationId = 5,
                ConsultationType = "Dentistry",

                Charge = 300
            }
            );
            modelsBuilder.Entity<ECGService>().HasData(

              new ECGService
              {

                  ECGServiceId = 1,
                  ECGServiceType = "Heart Fuctionality Test",
                  Charge = 2000


              },
             new ECGService
             {
                 ECGServiceId = 2,
                 ECGServiceType = "ECHO Cardiogram Test",
                 Charge = 3000


             },



             new ECGService
             {
                 ECGServiceId = 3,
                 ECGServiceType = "Trademill Test",
                 Charge = 1000

             }


             );
            modelsBuilder.Entity<RadiologyService>().HasData(

              new RadiologyService
              {

                  RadiologyServiceId = 1,
                  RadiologyType = "Xray",

                  Charge = 500


              },
             new RadiologyService
             {
                 RadiologyServiceId = 2,
                 RadiologyType = "CT Scan",

                 Charge = 400


             },



             new RadiologyService
             {
                 RadiologyServiceId = 3,
                 RadiologyType = "Ultrasound",

                 Charge = 600

             },
             new RadiologyService
             {
                 RadiologyServiceId = 4,
                 RadiologyType = "MRI",

                 Charge = 700

             }



             );
            modelsBuilder.Entity<LaboratoryService>().HasData(

             new LaboratoryService
             {

                 LaboratoryServiceId = 1,
                 LaboratoryType = "Liver Function Test",

                 Charge = 700


             },
            new LaboratoryService
            {
                LaboratoryServiceId = 2,
                LaboratoryType = "Throid Function Test",

                Charge = 400


            },



            new LaboratoryService
            {
                LaboratoryServiceId = 3,
                LaboratoryType = "Renal Function Test",

                Charge = 600

            },
            new LaboratoryService
            {
                LaboratoryServiceId = 4,
                LaboratoryType = "Blood Sugar Test",

                Charge = 900

            },
             new LaboratoryService
             {
                 LaboratoryServiceId = 5,
                 LaboratoryType = "Gastric Function Test",

                 Charge = 300

             }



            );
        }
    }
}

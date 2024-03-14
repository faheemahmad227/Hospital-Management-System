﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientRecordsService.Models;

namespace PatientRecordsService.Migrations
{
    [DbContext(typeof(PatientRecordDbContext))]
    partial class PatientRecordDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PatientRecordsService.Models.PatientTreatmentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Prescriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recommendations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PatientTreatmentDetails");
                });

            modelBuilder.Entity("PatientRecordsService.Models.TestRecord", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId");

                    b.ToTable("TestRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
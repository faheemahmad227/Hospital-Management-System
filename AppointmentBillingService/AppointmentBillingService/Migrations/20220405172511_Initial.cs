using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentBillingService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmbulanceServices",
                columns: table => new
                {
                    AmbulanceServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charge = table.Column<int>(nullable: false),
                    AmbulanceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbulanceServices", x => x.AmbulanceServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    BillingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    FacilityAppointmentId = table.Column<int>(nullable: false),
                    ConsultationsCharge = table.Column<int>(nullable: false),
                    LaboratoryServiceCharge = table.Column<int>(nullable: false),
                    PhysiotherapyServiceCharge = table.Column<int>(nullable: false),
                    ECGServiceCharge = table.Column<int>(nullable: false),
                    RadiologyServiceCharge = table.Column<int>(nullable: false),
                    AmbulanceServiceCharge = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<int>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.BillingId);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    ConsultationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultationType = table.Column<string>(nullable: true),
                    Charge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.ConsultationId);
                });

            migrationBuilder.CreateTable(
                name: "DoctorAppointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    DateOfAppointment = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    MedicalHistory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAppointments", x => x.AppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "ECGServices",
                columns: table => new
                {
                    ECGServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charge = table.Column<int>(nullable: false),
                    ECGServiceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECGServices", x => x.ECGServiceId);
                });

            migrationBuilder.CreateTable(
                name: "FacilityAppointments",
                columns: table => new
                {
                    FacilityAppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    PhysiotherapyServiceId = table.Column<int>(nullable: true),
                    LaboratoryServiceId = table.Column<int>(nullable: true),
                    ECGServiceId = table.Column<int>(nullable: true),
                    RadiologyServiceId = table.Column<int>(nullable: true),
                    AmbulanceServiceId = table.Column<int>(nullable: true),
                    ConsultationId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityAppointments", x => x.FacilityAppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryServices",
                columns: table => new
                {
                    LaboratoryServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaboratoryType = table.Column<string>(nullable: true),
                    Charge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryServices", x => x.LaboratoryServiceId);
                });

            migrationBuilder.CreateTable(
                name: "PhysiotherapyServices",
                columns: table => new
                {
                    PhysiotherapyServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charge = table.Column<int>(nullable: false),
                    PhysiotherapyType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysiotherapyServices", x => x.PhysiotherapyServiceId);
                });

            migrationBuilder.CreateTable(
                name: "RadiologyService",
                columns: table => new
                {
                    RadiologyServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charge = table.Column<int>(nullable: false),
                    RadiologyType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadiologyService", x => x.RadiologyServiceId);
                });

            migrationBuilder.InsertData(
                table: "AmbulanceServices",
                columns: new[] { "AmbulanceServiceId", "AmbulanceType", "Charge" },
                values: new object[,]
                {
                    { 1, "Air Ambulance", 2000 },
                    { 2, "Life Support Ambulance", 1000 },
                    { 3, "Isolation Ambulance", 3000 }
                });

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "ConsultationId", "Charge", "ConsultationType" },
                values: new object[,]
                {
                    { 1, 500, "Dermatology" },
                    { 2, 400, "General Medicine" },
                    { 3, 450, "Gynaecology" },
                    { 4, 600, "Neurology" },
                    { 5, 300, "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "ECGServices",
                columns: new[] { "ECGServiceId", "Charge", "ECGServiceType" },
                values: new object[,]
                {
                    { 1, 2000, "Heart Fuctionality Test" },
                    { 2, 3000, "ECHO Cardiogram Test" },
                    { 3, 1000, "Trademill Test" }
                });

            migrationBuilder.InsertData(
                table: "LaboratoryServices",
                columns: new[] { "LaboratoryServiceId", "Charge", "LaboratoryType" },
                values: new object[,]
                {
                    { 5, 300, "Gastric Function Test" },
                    { 4, 900, "Blood Sugar Test" },
                    { 1, 700, "Liver Function Test" },
                    { 2, 400, "Throid Function Test" },
                    { 3, 600, "Renal Function Test" }
                });

            migrationBuilder.InsertData(
                table: "PhysiotherapyServices",
                columns: new[] { "PhysiotherapyServiceId", "Charge", "PhysiotherapyType" },
                values: new object[,]
                {
                    { 1, 1000, "Sports Physiotherapy" },
                    { 2, 2000, "Pain Management" },
                    { 3, 3000, "Neurological physiotherapy" }
                });

            migrationBuilder.InsertData(
                table: "RadiologyService",
                columns: new[] { "RadiologyServiceId", "Charge", "RadiologyType" },
                values: new object[,]
                {
                    { 3, 600, "Ultrasound" },
                    { 1, 500, "Xray" },
                    { 2, 400, "CT Scan" },
                    { 4, 700, "MRI" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmbulanceServices");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "DoctorAppointments");

            migrationBuilder.DropTable(
                name: "ECGServices");

            migrationBuilder.DropTable(
                name: "FacilityAppointments");

            migrationBuilder.DropTable(
                name: "LaboratoryServices");

            migrationBuilder.DropTable(
                name: "PhysiotherapyServices");

            migrationBuilder.DropTable(
                name: "RadiologyService");
        }
    }
}

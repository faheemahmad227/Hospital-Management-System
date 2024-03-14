using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorFeedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    DoctorsFeedback = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorFeedbacks", x => x.FeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "FacilityFeedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    FacilitiesFeedback = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityFeedbacks", x => x.FeedbackId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorFeedbacks");

            migrationBuilder.DropTable(
                name: "FacilityFeedbacks");
        }
    }
}

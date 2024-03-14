using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentBillingService.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityAppointmentId",
                table: "Billings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacilityAppointmentId",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

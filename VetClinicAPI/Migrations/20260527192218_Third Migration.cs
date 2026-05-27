using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicAPI.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Diagnosos",
                table: "MedicalRecords",
                newName: "Diagnosis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Diagnosis",
                table: "MedicalRecords",
                newName: "Diagnosos");
        }
    }
}

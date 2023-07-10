using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaWebServices.Migrations
{
    /// <inheritdoc />
    public partial class FixEnrollment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentSection_Enrollments_id_section",
                table: "EnrollmentSection");

            migrationBuilder.DropColumn(
                name: "id_section",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "id_section",
                table: "EnrollmentSection",
                newName: "enrollmentsid");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentSection_Enrollments_enrollmentsid",
                table: "EnrollmentSection",
                column: "enrollmentsid",
                principalTable: "Enrollments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrollmentSection_Enrollments_enrollmentsid",
                table: "EnrollmentSection");

            migrationBuilder.RenameColumn(
                name: "enrollmentsid",
                table: "EnrollmentSection",
                newName: "id_section");

            migrationBuilder.AddColumn<int>(
                name: "id_section",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrollmentSection_Enrollments_id_section",
                table: "EnrollmentSection",
                column: "id_section",
                principalTable: "Enrollments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

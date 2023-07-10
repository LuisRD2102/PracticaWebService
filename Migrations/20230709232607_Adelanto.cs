using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaWebServices.Migrations
{
    /// <inheritdoc />
    public partial class Adelanto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Persons_id_persona",
                table: "Enrollments");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_persona",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Persons_id_persona",
                table: "Enrollments",
                column: "id_persona",
                principalTable: "Persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Persons_id_persona",
                table: "Enrollments");

            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "Sections",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "id_persona",
                table: "Enrollments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Persons_id_persona",
                table: "Enrollments",
                column: "id_persona",
                principalTable: "Persons",
                principalColumn: "id");
        }
    }
}

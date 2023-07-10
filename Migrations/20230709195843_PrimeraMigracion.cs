using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaWebServices.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    deleted_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    deleted_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ci = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    deleted_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_faculty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.id);
                    table.ForeignKey(
                        name: "FK_Schools_Faculties_id_faculty",
                        column: x => x.id_faculty,
                        principalTable: "Faculties",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    id_persona = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Persons_id_persona",
                        column: x => x.id_persona,
                        principalTable: "Persons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    deleted_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uc = table.Column<int>(type: "int", nullable: false),
                    semester = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    ht = table.Column<float>(type: "real", nullable: false),
                    hp = table.Column<float>(type: "real", nullable: false),
                    hl = table.Column<float>(type: "real", nullable: false),
                    id_school = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sections_Schools_id_school",
                        column: x => x.id_school,
                        principalTable: "Schools",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentSection",
                columns: table => new
                {
                    enrollmentsid = table.Column<int>(type: "int", nullable: false),
                    sectionsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentSection", x => new { x.enrollmentsid, x.sectionsid });
                    table.ForeignKey(
                        name: "FK_EnrollmentSection_Enrollments_enrollmentsid",
                        column: x => x.enrollmentsid,
                        principalTable: "Enrollments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentSection_Sections_sectionsid",
                        column: x => x.sectionsid,
                        principalTable: "Sections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_id_persona",
                table: "Enrollments",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentSection_sectionsid",
                table: "EnrollmentSection",
                column: "sectionsid");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_id_faculty",
                table: "Schools",
                column: "id_faculty");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_id_school",
                table: "Sections",
                column: "id_school");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollmentSection");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}

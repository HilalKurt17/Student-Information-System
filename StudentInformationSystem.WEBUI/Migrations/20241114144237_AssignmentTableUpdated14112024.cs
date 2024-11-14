using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssignmentTableUpdated14112024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentAssignmentFilePath",
                table: "Assignments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherAssignmentFilePath",
                table: "Assignments",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentAssignmentFilePath",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TeacherAssignmentFilePath",
                table: "Assignments");
        }
    }
}

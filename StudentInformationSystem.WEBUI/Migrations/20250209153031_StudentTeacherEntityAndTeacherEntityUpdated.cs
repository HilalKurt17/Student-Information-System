using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherEntityAndTeacherEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentTeacherComment",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "TeacherLessonScore",
                table: "StudentTeachers");

            migrationBuilder.AddColumn<int>(
                name: "votedStudentsCount",
                table: "Teachers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "votedStudentsCount",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "StudentTeacherComment",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherLessonScore",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeacherLessonIsCheckedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Lessons");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "TeacherLessons",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "TeacherLessons");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Lessons",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}

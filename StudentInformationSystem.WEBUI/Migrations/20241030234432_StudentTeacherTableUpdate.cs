using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonDuration",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "StudentRequest",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "StudentRequestDetails",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "TeacherRespond",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "TeacherRespondDetails",
                table: "StudentTeachers");

            migrationBuilder.RenameColumn(
                name: "LessonTime",
                table: "StudentTeachers",
                newName: "LessonStartTime");

            migrationBuilder.AlterColumn<string>(
                name: "LessonDate",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EnrollmentState",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonEndTime",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonEndTime",
                table: "StudentTeachers");

            migrationBuilder.RenameColumn(
                name: "LessonStartTime",
                table: "StudentTeachers",
                newName: "LessonTime");

            migrationBuilder.AlterColumn<string>(
                name: "LessonDate",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "EnrollmentState",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "LessonDuration",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "StudentRequest",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentRequestDetails",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TeacherRespond",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherRespondDetails",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);
        }
    }
}

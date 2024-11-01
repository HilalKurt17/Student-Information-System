using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ELClassification",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnrollmentState",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonDate",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonDetails",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonDuration",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LessonEndDate",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<char>(
                name: "LessonMode",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: false
                );

            migrationBuilder.AddColumn<string>(
                name: "LessonName",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LessonPrice",
                table: "StudentTeachers",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LessonStartDate",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "LessonTime",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "PrivateLessonID",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ELClassification",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "EnrollmentState",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonDate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonDetails",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonDuration",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonEndDate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonMode",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonName",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonPrice",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonStartDate",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "LessonTime",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "PrivateLessonID",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "StudentRequest",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "StudentRequestDetails",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "StudentTeacherComment",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "TeacherLessonScore",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "TeacherRespond",
                table: "StudentTeachers");

            migrationBuilder.DropColumn(
                name: "TeacherRespondDetails",
                table: "StudentTeachers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachers_Students_StudentID",
                table: "StudentTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers");

            migrationBuilder.AlterColumn<int>(
                name: "PrivateLessonID",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers",
                column: "PrivateLessonID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeachers_StudentID_TeacherID",
                table: "StudentTeachers",
                columns: new[] { "StudentID", "TeacherID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachers_Students_StudentID",
                table: "StudentTeachers",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTeachers_Students_StudentID",
                table: "StudentTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers");

            migrationBuilder.DropIndex(
                name: "IX_StudentTeachers_StudentID_TeacherID",
                table: "StudentTeachers");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrivateLessonID",
                table: "StudentTeachers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTeachers",
                table: "StudentTeachers",
                columns: new[] { "StudentID", "TeacherID" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTeachers_Students_StudentID",
                table: "StudentTeachers",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

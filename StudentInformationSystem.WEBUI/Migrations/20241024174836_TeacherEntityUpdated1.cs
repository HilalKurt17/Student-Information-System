using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeacherEntityUpdated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnenrollmentDate",
                table: "Teachers");

            migrationBuilder.AddColumn<bool>(
                name: "UnenrollmentState",
                table: "Teachers",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnenrollmentState",
                table: "Teachers");

            migrationBuilder.AddColumn<DateTime>(
                name: "UnenrollmentDate",
                table: "Teachers",
                type: "TEXT",
                nullable: true);
        }
    }
}

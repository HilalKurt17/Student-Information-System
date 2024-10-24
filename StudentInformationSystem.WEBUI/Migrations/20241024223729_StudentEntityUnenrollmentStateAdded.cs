using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentEntityUnenrollmentStateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnenrollmentDate",
                table: "Students");

            migrationBuilder.AddColumn<bool>(
                name: "UnenrollmentState",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnenrollmentState",
                table: "Students");

            migrationBuilder.AddColumn<DateTime>(
                name: "UnenrollmentDate",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }
    }
}

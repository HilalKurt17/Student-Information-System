﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "LessonMode",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(char),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "LessonMode",
                table: "StudentTeachers",
                type: "TEXT",
                nullable: false,
                defaultValue: ' ',
                oldClrType: typeof(char),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PasswordsTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    PasswordsID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userMail = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.PasswordsID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passwords");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTeamProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateduserprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserProfile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

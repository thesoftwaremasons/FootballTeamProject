using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTeamProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class added_clubname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClubName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClubName",
                table: "AspNetUsers");
        }
    }
}

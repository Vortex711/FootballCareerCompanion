using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballCareerMode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExtraCareerAndSeasonFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Expectation",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeaguePosition",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Careers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expectation",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "LeaguePosition",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Careers");
        }
    }
}

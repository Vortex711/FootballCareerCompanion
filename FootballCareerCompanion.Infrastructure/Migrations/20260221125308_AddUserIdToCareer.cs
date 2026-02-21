using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballCareerCompanion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToCareer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Careers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Careers_UserId",
                table: "Careers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Careers_Users_UserId",
                table: "Careers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Careers_Users_UserId",
                table: "Careers");

            migrationBuilder.DropIndex(
                name: "IX_Careers_UserId",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Careers");
        }
    }
}

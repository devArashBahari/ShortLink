using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class createlink2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "shortUrls");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "requestUrls");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Os");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "browsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "shortUrls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "requestUrls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "Os",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsDeleted",
                table: "browsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Migrations
{
    public partial class Military : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitaryCategory",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitaryGroup",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitaryHealth",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitaryInstitution",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitaryPosition",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitaryProfession",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitarySpecialNumber",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilitaryUnit",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Posted",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ResignationReason",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitaryCategory",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitaryGroup",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitaryHealth",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitaryInstitution",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitaryPosition",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitaryProfession",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitarySpecialNumber",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MilitaryUnit",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Posted",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ResignationReason",
                table: "Cards");
        }
    }
}

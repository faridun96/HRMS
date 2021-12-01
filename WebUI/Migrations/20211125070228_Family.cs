using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Migrations
{
    public partial class Family : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AfterSchool",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AllWorkDuration",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContiniousAllWorkDuration",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diploma",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationType",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyStatus",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralProfession",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInUnion",
                table: "Cards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastJob",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Party",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportDate",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PassportIssuer",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportSerie",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterSchool",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "AllWorkDuration",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ContiniousAllWorkDuration",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Diploma",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "EducationType",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FamilyStatus",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "GeneralProfession",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsInUnion",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "LastJob",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Party",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PassportDate",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PassportIssuer",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PassportSerie",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

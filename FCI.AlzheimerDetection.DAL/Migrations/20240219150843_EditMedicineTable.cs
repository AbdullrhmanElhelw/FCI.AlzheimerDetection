using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCI.AlzheimerDetection.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditMedicineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expired",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Medicines");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expired",
                table: "RelativeMedicine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "RelativeMedicine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expired",
                table: "RelativeMedicine");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "RelativeMedicine");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medicines");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expired",
                table: "Medicines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Medicines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

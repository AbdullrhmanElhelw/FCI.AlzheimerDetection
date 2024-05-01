using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCI.AlzheimerDetection.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: ["Id", "Name", "NormalizedName", "ConcurrencyStamp"],
                values: new object[,]
                {
                      { 1, "Admin", "ADMIN", "1" },
                      { 2, "Relative", "RELATIVE", "2" },
                      { 3, "NormalUser", "NORMALUSER", "3" }
                }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
        }
    }
}
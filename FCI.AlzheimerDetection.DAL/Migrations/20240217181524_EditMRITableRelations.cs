using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCI.AlzheimerDetection.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditMRITableRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormalUser_Image",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_MRIs",
                table: "MRIs");

            migrationBuilder.DropForeignKey(
                name: "FK_MRIs_NormalUsers_NormalUserId",
                table: "MRIs");

            migrationBuilder.DropIndex(
                name: "IX_MRIs_AdminId",
                table: "MRIs");

            migrationBuilder.DropIndex(
                name: "IX_MRIs_NormalUserId",
                table: "MRIs");

            migrationBuilder.DropIndex(
                name: "IX_Images_NormalUserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "NormalUsers");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "MRIs");

            migrationBuilder.DropColumn(
                name: "NormalUserId",
                table: "MRIs");

            migrationBuilder.DropColumn(
                name: "NormalUserId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "AdminMRI",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    MRIId = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMRI", x => new { x.AdminId, x.MRIId });
                    table.ForeignKey(
                        name: "FK_AdminMRI_MRIs_MRIId",
                        column: x => x.MRIId,
                        principalTable: "MRIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_MRIs",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NormalUserMRI",
                columns: table => new
                {
                    NormalUserId = table.Column<int>(type: "int", nullable: false),
                    MRIId = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalUserMRI", x => new { x.NormalUserId, x.MRIId });
                    table.ForeignKey(
                        name: "FK_NormalUserMRI_MRIs_MRIId",
                        column: x => x.MRIId,
                        principalTable: "MRIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormalUser_NormalUserMRIs",
                        column: x => x.NormalUserId,
                        principalTable: "NormalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminMRI_MRIId",
                table: "AdminMRI",
                column: "MRIId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalUserMRI_MRIId",
                table: "NormalUserMRI",
                column: "MRIId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMRI");

            migrationBuilder.DropTable(
                name: "NormalUserMRI");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "NormalUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "MRIs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NormalUserId",
                table: "MRIs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NormalUserId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MRIs_AdminId",
                table: "MRIs",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MRIs_NormalUserId",
                table: "MRIs",
                column: "NormalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NormalUserId",
                table: "Images",
                column: "NormalUserId",
                unique: true,
                filter: "[NormalUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_NormalUser_Image",
                table: "Images",
                column: "NormalUserId",
                principalTable: "NormalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_MRIs",
                table: "MRIs",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MRIs_NormalUsers_NormalUserId",
                table: "MRIs",
                column: "NormalUserId",
                principalTable: "NormalUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

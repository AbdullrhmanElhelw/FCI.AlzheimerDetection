using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCI.AlzheimerDetection.DAL.Migrations;

/// <inheritdoc />
public partial class ConfigureRelations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "AdminId",
            table: "Reports",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "AdminId",
            table: "Patients",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedAt",
            table: "Patients",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<string>(
            name: "FirstName",
            table: "Patients",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<int>(
            name: "ImageId",
            table: "Patients",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "Patients",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<string>(
            name: "LastName",
            table: "Patients",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<DateTime>(
            name: "UpdatedAt",
            table: "Patients",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
            name: "AdminId",
            table: "Medicines",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "NormalUserId",
            table: "Images",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "PatientId",
            table: "Images",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateTable(
            name: "AddRelative",
            columns: table => new
            {
                AdminId = table.Column<int>(type: "int", nullable: false),
                PatientId = table.Column<int>(type: "int", nullable: false),
                RelativeId = table.Column<int>(type: "int", nullable: false),
                AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AddRelative", x => new { x.RelativeId, x.AdminId, x.PatientId });
                table.ForeignKey(
                    name: "FK_Admin_AddRelatives",
                    column: x => x.AdminId,
                    principalTable: "Admins",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_Patient_AddRelatives",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_Relative_AddRelatives",
                    column: x => x.RelativeId,
                    principalTable: "Relatives",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateTable(
            name: "RelativeMedicine",
            columns: table => new
            {
                RelativeId = table.Column<int>(type: "int", nullable: false),
                MedicineId = table.Column<int>(type: "int", nullable: false),
                SetedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RelativeMedicine", x => new { x.RelativeId, x.MedicineId });
                table.ForeignKey(
                    name: "FK_Medicine_Relatives",
                    column: x => x.MedicineId,
                    principalTable: "Medicines",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_Relative_Medicines",
                    column: x => x.RelativeId,
                    principalTable: "Relatives",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Reports_AdminId",
            table: "Reports",
            column: "AdminId");

        migrationBuilder.CreateIndex(
            name: "IX_Patients_AdminId",
            table: "Patients",
            column: "AdminId");

        migrationBuilder.CreateIndex(
            name: "IX_MRIs_AdminId",
            table: "MRIs",
            column: "AdminId");

        migrationBuilder.CreateIndex(
            name: "IX_MRIs_NormalUserId",
            table: "MRIs",
            column: "NormalUserId");

        migrationBuilder.CreateIndex(
            name: "IX_Medicines_AdminId",
            table: "Medicines",
            column: "AdminId");

        migrationBuilder.CreateIndex(
            name: "IX_Images_NormalUserId",
            table: "Images",
            column: "NormalUserId",
            unique: true,
            filter: "[NormalUserId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Images_PatientId",
            table: "Images",
            column: "PatientId",
            unique: true,
            filter: "[PatientId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_AddRelative_AdminId",
            table: "AddRelative",
            column: "AdminId");

        migrationBuilder.CreateIndex(
            name: "IX_AddRelative_PatientId",
            table: "AddRelative",
            column: "PatientId");

        migrationBuilder.CreateIndex(
            name: "IX_RelativeMedicine_MedicineId",
            table: "RelativeMedicine",
            column: "MedicineId");

        migrationBuilder.AddForeignKey(
            name: "FK_NormalUser_Image",
            table: "Images",
            column: "NormalUserId",
            principalTable: "NormalUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);

        migrationBuilder.AddForeignKey(
            name: "FK_Patient_Image",
            table: "Images",
            column: "PatientId",
            principalTable: "Patients",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);

        migrationBuilder.AddForeignKey(
            name: "FK_Admin_Medicines",
            table: "Medicines",
            column: "AdminId",
            principalTable: "Admins",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);

        migrationBuilder.AddForeignKey(
            name: "FK_Admin_MRIs",
            table: "MRIs",
            column: "AdminId",
            principalTable: "Admins",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);

        migrationBuilder.AddForeignKey(
            name: "FK_MRIs_NormalUsers_NormalUserId",
            table: "MRIs",
            column: "NormalUserId",
            principalTable: "NormalUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);

        migrationBuilder.AddForeignKey(
            name: "FK_Admin_Patients",
            table: "Patients",
            column: "AdminId",
            principalTable: "Admins",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);

        migrationBuilder.AddForeignKey(
            name: "FK_Admin_Reports",
            table: "Reports",
            column: "AdminId",
            principalTable: "Admins",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_NormalUser_Image",
            table: "Images");

        migrationBuilder.DropForeignKey(
            name: "FK_Patient_Image",
            table: "Images");

        migrationBuilder.DropForeignKey(
            name: "FK_Admin_Medicines",
            table: "Medicines");

        migrationBuilder.DropForeignKey(
            name: "FK_Admin_MRIs",
            table: "MRIs");

        migrationBuilder.DropForeignKey(
            name: "FK_MRIs_NormalUsers_NormalUserId",
            table: "MRIs");

        migrationBuilder.DropForeignKey(
            name: "FK_Admin_Patients",
            table: "Patients");

        migrationBuilder.DropForeignKey(
            name: "FK_Admin_Reports",
            table: "Reports");

        migrationBuilder.DropTable(
            name: "AddRelative");

        migrationBuilder.DropTable(
            name: "RelativeMedicine");

        migrationBuilder.DropIndex(
            name: "IX_Reports_AdminId",
            table: "Reports");

        migrationBuilder.DropIndex(
            name: "IX_Patients_AdminId",
            table: "Patients");

        migrationBuilder.DropIndex(
            name: "IX_MRIs_AdminId",
            table: "MRIs");

        migrationBuilder.DropIndex(
            name: "IX_MRIs_NormalUserId",
            table: "MRIs");

        migrationBuilder.DropIndex(
            name: "IX_Medicines_AdminId",
            table: "Medicines");

        migrationBuilder.DropIndex(
            name: "IX_Images_NormalUserId",
            table: "Images");

        migrationBuilder.DropIndex(
            name: "IX_Images_PatientId",
            table: "Images");

        migrationBuilder.DropColumn(
            name: "AdminId",
            table: "Reports");

        migrationBuilder.DropColumn(
            name: "AdminId",
            table: "Patients");

        migrationBuilder.DropColumn(
            name: "CreatedAt",
            table: "Patients");

        migrationBuilder.DropColumn(
            name: "FirstName",
            table: "Patients");

        migrationBuilder.DropColumn(
            name: "ImageId",
            table: "Patients");

        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "Patients");

        migrationBuilder.DropColumn(
            name: "LastName",
            table: "Patients");

        migrationBuilder.DropColumn(
            name: "UpdatedAt",
            table: "Patients");

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
            name: "AdminId",
            table: "Medicines");

        migrationBuilder.DropColumn(
            name: "NormalUserId",
            table: "Images");

        migrationBuilder.DropColumn(
            name: "PatientId",
            table: "Images");
    }
}
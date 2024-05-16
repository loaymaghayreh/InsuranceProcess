using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnosesCodes",
                columns: table => new
                {
                    DiagnosesCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosesCodes", x => x.DiagnosesCodeId);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.InsuranceCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "PrescribedItems",
                columns: table => new
                {
                    PrescribedItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedItems", x => x.PrescribedItemId);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionAttachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionAttachments", x => x.AttachmentId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerApplications",
                columns: table => new
                {
                    CustomerNationalID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerApplications", x => x.CustomerNationalID);
                    table.ForeignKey(
                        name: "FK_CustomerApplications_PrescriptionAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "PrescriptionAttachments",
                        principalColumn: "AttachmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerApplicationDiagnosisCode",
                columns: table => new
                {
                    CustomerNationalID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiagnosesCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerApplicationDiagnosisCode", x => new { x.CustomerNationalID, x.DiagnosesCodeId });
                    table.ForeignKey(
                        name: "FK_CustomerApplicationDiagnosisCode_CustomerApplications_CustomerNationalID",
                        column: x => x.CustomerNationalID,
                        principalTable: "CustomerApplications",
                        principalColumn: "CustomerNationalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerApplicationDiagnosisCode_DiagnosesCodes_DiagnosesCodeId",
                        column: x => x.DiagnosesCodeId,
                        principalTable: "DiagnosesCodes",
                        principalColumn: "DiagnosesCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerApplicationPrescribedItem",
                columns: table => new
                {
                    CustomerNationalID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrescribedItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerApplicationPrescribedItem", x => new { x.CustomerNationalID, x.PrescribedItemId });
                    table.ForeignKey(
                        name: "FK_CustomerApplicationPrescribedItem_CustomerApplications_CustomerNationalID",
                        column: x => x.CustomerNationalID,
                        principalTable: "CustomerApplications",
                        principalColumn: "CustomerNationalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerApplicationPrescribedItem_PrescribedItems_PrescribedItemId",
                        column: x => x.PrescribedItemId,
                        principalTable: "PrescribedItems",
                        principalColumn: "PrescribedItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerApplicationDiagnosisCode_DiagnosesCodeId",
                table: "CustomerApplicationDiagnosisCode",
                column: "DiagnosesCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerApplicationPrescribedItem_PrescribedItemId",
                table: "CustomerApplicationPrescribedItem",
                column: "PrescribedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerApplications_AttachmentId",
                table: "CustomerApplications",
                column: "AttachmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerApplicationDiagnosisCode");

            migrationBuilder.DropTable(
                name: "CustomerApplicationPrescribedItem");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");

            migrationBuilder.DropTable(
                name: "DiagnosesCodes");

            migrationBuilder.DropTable(
                name: "CustomerApplications");

            migrationBuilder.DropTable(
                name: "PrescribedItems");

            migrationBuilder.DropTable(
                name: "PrescriptionAttachments");
        }
    }
}

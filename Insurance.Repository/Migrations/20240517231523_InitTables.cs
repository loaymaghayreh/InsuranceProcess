using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnosesCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosesCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrescribedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescribedItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerApplications",
                columns: table => new
                {
                    CustomerApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerApplications", x => x.CustomerApplicationId);
                    table.ForeignKey(
                        name: "FK_CustomerApplications_InsuranceCompanies_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "InsuranceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerApplicationDiagnosesCode",
                columns: table => new
                {
                    CustomerApplicationId = table.Column<int>(type: "int", nullable: false),
                    DiagnosesCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerApplicationDiagnosesCode", x => new { x.CustomerApplicationId, x.DiagnosesCodeId });
                    table.ForeignKey(
                        name: "FK_CustomerApplicationDiagnosesCode_CustomerApplications_CustomerApplicationId",
                        column: x => x.CustomerApplicationId,
                        principalTable: "CustomerApplications",
                        principalColumn: "CustomerApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerApplicationDiagnosesCode_DiagnosesCodes_DiagnosesCodeId",
                        column: x => x.DiagnosesCodeId,
                        principalTable: "DiagnosesCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerApplicationPrescribedItem",
                columns: table => new
                {
                    CustomerApplicationId = table.Column<int>(type: "int", nullable: false),
                    PrescribedItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerApplicationPrescribedItem", x => new { x.CustomerApplicationId, x.PrescribedItemId });
                    table.ForeignKey(
                        name: "FK_CustomerApplicationPrescribedItem_CustomerApplications_CustomerApplicationId",
                        column: x => x.CustomerApplicationId,
                        principalTable: "CustomerApplications",
                        principalColumn: "CustomerApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerApplicationPrescribedItem_PrescribedItems_PrescribedItemId",
                        column: x => x.PrescribedItemId,
                        principalTable: "PrescribedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionAttachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionAttachments", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_PrescriptionAttachments_CustomerApplications_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "CustomerApplications",
                        principalColumn: "CustomerApplicationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerApplicationDiagnosesCode_DiagnosesCodeId",
                table: "CustomerApplicationDiagnosesCode",
                column: "DiagnosesCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerApplicationPrescribedItem_PrescribedItemId",
                table: "CustomerApplicationPrescribedItem",
                column: "PrescribedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerApplications_InsuranceCompanyId",
                table: "CustomerApplications",
                column: "InsuranceCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerApplicationDiagnosesCode");

            migrationBuilder.DropTable(
                name: "CustomerApplicationPrescribedItem");

            migrationBuilder.DropTable(
                name: "PrescriptionAttachments");

            migrationBuilder.DropTable(
                name: "DiagnosesCodes");

            migrationBuilder.DropTable(
                name: "PrescribedItems");

            migrationBuilder.DropTable(
                name: "CustomerApplications");

            migrationBuilder.DropTable(
                name: "InsuranceCompanies");
        }
    }
}

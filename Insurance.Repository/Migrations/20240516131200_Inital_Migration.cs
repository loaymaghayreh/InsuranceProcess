using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "insuranceCompanies",
                columns: table => new
                {
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insuranceCompanies", x => x.InsuranceCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "prescriptionAttachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptionAttachments", x => x.AttachmentId);
                });

            migrationBuilder.CreateTable(
                name: "customerApplications",
                columns: table => new
                {
                    NationalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompanyId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerApplications", x => x.NationalID);
                    table.ForeignKey(
                        name: "FK_customerApplications_prescriptionAttachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "prescriptionAttachments",
                        principalColumn: "AttachmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diagnosesCodes",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerApplicationNationalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosesCodes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_diagnosesCodes_customerApplications_CustomerApplicationNationalID",
                        column: x => x.CustomerApplicationNationalID,
                        principalTable: "customerApplications",
                        principalColumn: "NationalID");
                });

            migrationBuilder.CreateTable(
                name: "prescribedItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerApplicationNationalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescribedItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_prescribedItems_customerApplications_CustomerApplicationNationalID",
                        column: x => x.CustomerApplicationNationalID,
                        principalTable: "customerApplications",
                        principalColumn: "NationalID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerApplications_AttachmentId",
                table: "customerApplications",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosesCodes_CustomerApplicationNationalID",
                table: "diagnosesCodes",
                column: "CustomerApplicationNationalID");

            migrationBuilder.CreateIndex(
                name: "IX_prescribedItems_CustomerApplicationNationalID",
                table: "prescribedItems",
                column: "CustomerApplicationNationalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diagnosesCodes");

            migrationBuilder.DropTable(
                name: "insuranceCompanies");

            migrationBuilder.DropTable(
                name: "prescribedItems");

            migrationBuilder.DropTable(
                name: "customerApplications");

            migrationBuilder.DropTable(
                name: "prescriptionAttachments");
        }
    }
}

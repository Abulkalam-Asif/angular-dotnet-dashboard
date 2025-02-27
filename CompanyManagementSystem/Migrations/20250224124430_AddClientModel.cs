using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddClientModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PAN_No = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Station = table.Column<string>(type: "TEXT", nullable: false),
                    Credit_Period = table.Column<int>(type: "INTEGER", nullable: false),
                    GST_No = table.Column<string>(type: "TEXT", nullable: false),
                    CIN_No = table.Column<string>(type: "TEXT", nullable: false),
                    IEC_No = table.Column<string>(type: "TEXT", nullable: false),
                    GST_Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    SAC_Code = table.Column<int>(type: "INTEGER", nullable: false),
                    LedgerCompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    VAT_No = table.Column<string>(type: "TEXT", nullable: false),
                    TIN_no = table.Column<string>(type: "TEXT", nullable: false),
                    ST_No = table.Column<string>(type: "TEXT", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_Mobile = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_Email = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_Address = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_State = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_Country = table.Column<string>(type: "TEXT", nullable: false),
                    Contact_Pincode = table.Column<string>(type: "TEXT", nullable: false),
                    Is_Invoice_Format = table.Column<bool>(type: "INTEGER", nullable: false),
                    Is_KYC = table.Column<bool>(type: "INTEGER", nullable: false),
                    State_Code = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_LedgerCompanyId",
                        column: x => x.LedgerCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LedgerCompanyId",
                table: "Clients",
                column: "LedgerCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

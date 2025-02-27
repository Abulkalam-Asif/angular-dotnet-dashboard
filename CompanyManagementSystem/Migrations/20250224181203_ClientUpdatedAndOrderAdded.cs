using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ClientUpdatedAndOrderAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit_Period",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Is_Invoice_Format",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Is_KYC",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "VAT_No",
                table: "Clients",
                newName: "VATNo");

            migrationBuilder.RenameColumn(
                name: "TIN_no",
                table: "Clients",
                newName: "TINno");

            migrationBuilder.RenameColumn(
                name: "State_Code",
                table: "Clients",
                newName: "IsKYC");

            migrationBuilder.RenameColumn(
                name: "ST_No",
                table: "Clients",
                newName: "StateCode");

            migrationBuilder.RenameColumn(
                name: "SAC_Code",
                table: "Clients",
                newName: "IsInvoiceFormat");

            migrationBuilder.RenameColumn(
                name: "PAN_No",
                table: "Clients",
                newName: "STNo");

            migrationBuilder.RenameColumn(
                name: "IEC_No",
                table: "Clients",
                newName: "SACCode");

            migrationBuilder.RenameColumn(
                name: "GST_No",
                table: "Clients",
                newName: "PANNo");

            migrationBuilder.RenameColumn(
                name: "GST_Date",
                table: "Clients",
                newName: "IECNo");

            migrationBuilder.RenameColumn(
                name: "Contact_State",
                table: "Clients",
                newName: "GSTNo");

            migrationBuilder.RenameColumn(
                name: "Contact_Pincode",
                table: "Clients",
                newName: "GSTDate");

            migrationBuilder.RenameColumn(
                name: "Contact_Name",
                table: "Clients",
                newName: "CreditPeriod");

            migrationBuilder.RenameColumn(
                name: "Contact_Mobile",
                table: "Clients",
                newName: "ContactState");

            migrationBuilder.RenameColumn(
                name: "Contact_Email",
                table: "Clients",
                newName: "ContactPincode");

            migrationBuilder.RenameColumn(
                name: "Contact_Country",
                table: "Clients",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "Contact_Address",
                table: "Clients",
                newName: "ContactMobile");

            migrationBuilder.RenameColumn(
                name: "CIN_No",
                table: "Clients",
                newName: "ContactEmail");

            migrationBuilder.AddColumn<string>(
                name: "CINNo",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactAddress",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactCountry",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNo = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    InvoicingTerms = table.Column<string>(type: "TEXT", nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", nullable: false),
                    ContactNo = table.Column<string>(type: "TEXT", nullable: false),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ContactFaxNo = table.Column<string>(type: "TEXT", nullable: false),
                    OtherRemarks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "CINNo",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ContactAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ContactCountry",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "VATNo",
                table: "Clients",
                newName: "VAT_No");

            migrationBuilder.RenameColumn(
                name: "TINno",
                table: "Clients",
                newName: "TIN_no");

            migrationBuilder.RenameColumn(
                name: "StateCode",
                table: "Clients",
                newName: "ST_No");

            migrationBuilder.RenameColumn(
                name: "STNo",
                table: "Clients",
                newName: "PAN_No");

            migrationBuilder.RenameColumn(
                name: "SACCode",
                table: "Clients",
                newName: "IEC_No");

            migrationBuilder.RenameColumn(
                name: "PANNo",
                table: "Clients",
                newName: "GST_No");

            migrationBuilder.RenameColumn(
                name: "IsKYC",
                table: "Clients",
                newName: "State_Code");

            migrationBuilder.RenameColumn(
                name: "IsInvoiceFormat",
                table: "Clients",
                newName: "SAC_Code");

            migrationBuilder.RenameColumn(
                name: "IECNo",
                table: "Clients",
                newName: "GST_Date");

            migrationBuilder.RenameColumn(
                name: "GSTNo",
                table: "Clients",
                newName: "Contact_State");

            migrationBuilder.RenameColumn(
                name: "GSTDate",
                table: "Clients",
                newName: "Contact_Pincode");

            migrationBuilder.RenameColumn(
                name: "CreditPeriod",
                table: "Clients",
                newName: "Contact_Name");

            migrationBuilder.RenameColumn(
                name: "ContactState",
                table: "Clients",
                newName: "Contact_Mobile");

            migrationBuilder.RenameColumn(
                name: "ContactPincode",
                table: "Clients",
                newName: "Contact_Email");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Clients",
                newName: "Contact_Country");

            migrationBuilder.RenameColumn(
                name: "ContactMobile",
                table: "Clients",
                newName: "Contact_Address");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "Clients",
                newName: "CIN_No");

            migrationBuilder.AddColumn<int>(
                name: "Credit_Period",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Invoice_Format",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_KYC",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}

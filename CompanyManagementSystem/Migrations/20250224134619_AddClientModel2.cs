using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddClientModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_LedgerCompanyId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_LedgerCompanyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LedgerCompanyId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "LedgerId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LedgerId",
                table: "Clients",
                column: "LedgerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_LedgerId",
                table: "Clients",
                column: "LedgerId",
                principalTable: "Companies",
                principalColumn: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_LedgerId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_LedgerId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LedgerId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "LedgerCompanyId",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LedgerCompanyId",
                table: "Clients",
                column: "LedgerCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_LedgerCompanyId",
                table: "Clients",
                column: "LedgerCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

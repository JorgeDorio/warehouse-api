using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Migrations
{
    /// <inheritdoc />
    public partial class AddFKAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CustomerId",
                table: "Adresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_CustomerId",
                table: "Adresses");
        }
    }
}

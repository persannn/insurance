using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance_Two_Tables.Migrations
{
    /// <inheritdoc />
    public partial class AddedAddressIdColumnToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressViewModel_Customer_CustomerId",
                table: "AddressViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerViewModel_Address_AddressId",
                table: "CustomerViewModel");

            migrationBuilder.DropIndex(
                name: "IX_CustomerViewModel_AddressId",
                table: "CustomerViewModel");

            migrationBuilder.DropIndex(
                name: "IX_AddressViewModel_CustomerId",
                table: "AddressViewModel");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AddressViewModel");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "AddressViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerViewModel_AddressId",
                table: "CustomerViewModel",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressViewModel_CustomerId",
                table: "AddressViewModel",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressViewModel_Customer_CustomerId",
                table: "AddressViewModel",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerViewModel_Address_AddressId",
                table: "CustomerViewModel",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

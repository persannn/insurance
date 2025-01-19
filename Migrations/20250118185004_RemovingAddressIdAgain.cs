using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance_Final_Version.Migrations
{
    /// <inheritdoc />
    public partial class RemovingAddressIdAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CustomerViewModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CustomerViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

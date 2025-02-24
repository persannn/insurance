using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance_Final_Version.Migrations
{
    /// <inheritdoc />
    public partial class CustomerIDColumnsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customer",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerViewModel");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customer");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance_Final_Version.Migrations
{
    /// <inheritdoc />
    public partial class AddedInsuranceTableToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Insurance",
                table: "CustomerViewModel");

            migrationBuilder.DropColumn(
                name: "Insurance",
                table: "Customer");

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InsuranceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceValue = table.Column<int>(type: "int", nullable: false),
                    CustomerViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurance_CustomerViewModel_CustomerViewModelId",
                        column: x => x.CustomerViewModelId,
                        principalTable: "CustomerViewModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Insurance_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_CustomerId",
                table: "Insurance",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_CustomerViewModelId",
                table: "Insurance",
                column: "CustomerViewModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.AddColumn<string>(
                name: "Insurance",
                table: "CustomerViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Insurance",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

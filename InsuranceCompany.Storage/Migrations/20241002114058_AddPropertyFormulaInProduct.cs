using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyFormulaInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Formula",
                table: "PRODUCTS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "PRODUCT_RISKS",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "PRODUCT_RISKS",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Formula",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "PRODUCT_RISKS");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "PRODUCT_RISKS");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsuranceCompany.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddProductRisk_AndRemoveRisk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CONTRACT_RISKS_RISKS_RiskId",
                table: "CONTRACT_RISKS");

            migrationBuilder.DropTable(
                name: "RISKS");

            migrationBuilder.DropIndex(
                name: "IX_CONTRACT_RISKS_RiskId",
                table: "CONTRACT_RISKS");

            migrationBuilder.DropColumn(
                name: "RiskId",
                table: "CONTRACT_RISKS");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PRODUCTS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CONTRACT_RISKS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PRODUCT_RISKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Premium = table.Column<decimal>(type: "numeric", nullable: true),
                    InsuranceSum = table.Column<decimal>(type: "numeric", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_RISKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_RISKS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_RISKS_ProductId",
                table: "PRODUCT_RISKS",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT_RISKS");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PRODUCTS");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CONTRACT_RISKS");

            migrationBuilder.AddColumn<int>(
                name: "RiskId",
                table: "CONTRACT_RISKS",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RISKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RISKS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACT_RISKS_RiskId",
                table: "CONTRACT_RISKS",
                column: "RiskId");

            migrationBuilder.AddForeignKey(
                name: "FK_CONTRACT_RISKS_RISKS_RiskId",
                table: "CONTRACT_RISKS",
                column: "RiskId",
                principalTable: "RISKS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

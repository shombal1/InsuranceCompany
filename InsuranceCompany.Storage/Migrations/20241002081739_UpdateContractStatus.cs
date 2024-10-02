using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Storage.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContractStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CONTRACTS");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CONTRACTS",
                type: "integer",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CONTRACTS");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CONTRACTS",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false);
        }
    }
}

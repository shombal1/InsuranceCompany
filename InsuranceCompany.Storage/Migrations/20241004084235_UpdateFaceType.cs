using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Storage.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFaceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "FACES");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "FACES",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "FACES");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "FACES",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false);
        }
    }
}

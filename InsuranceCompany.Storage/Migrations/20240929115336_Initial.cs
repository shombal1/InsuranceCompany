using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsuranceCompany.Storage.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FACES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    SecondName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Lastname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    DateBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    INN = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IKPS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IKPS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOBS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOBS", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "STATUSES_AGENT_CONTRACT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUSES_AGENT_CONTRACT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LOBId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_LOBS_LOBId",
                        column: x => x.LOBId,
                        principalTable: "LOBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateBegin = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DateEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FaceId = table.Column<int>(type: "integer", nullable: false),
                    IKPId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AGENTS_FACES_FaceId",
                        column: x => x.FaceId,
                        principalTable: "FACES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENTS_IKPS_IKPId",
                        column: x => x.IKPId,
                        principalTable: "IKPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENTS_STATUSES_AGENT_CONTRACT_StatusId",
                        column: x => x.StatusId,
                        principalTable: "STATUSES_AGENT_CONTRACT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_METAFIELDS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    JsonData = table.Column<string>(type: "json", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_METAFIELDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_METAFIELDS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGENT_AGREEMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    LOBId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENT_AGREEMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AGENT_AGREEMENTS_AGENTS_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AGENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENT_AGREEMENTS_LOBS_LOBId",
                        column: x => x.LOBId,
                        principalTable: "LOBS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONTRACTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateSign = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Premium = table.Column<decimal>(type: "numeric", nullable: true),
                    InsuranceSum = table.Column<decimal>(type: "numeric", nullable: true),
                    Rate = table.Column<decimal>(type: "numeric", nullable: true),
                    Commission = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    PolicyHolderId = table.Column<int>(type: "integer", nullable: true),
                    InsuredPersonId = table.Column<int>(type: "integer", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTRACTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTRACTS_AGENTS_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AGENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONTRACTS_FACES_InsuredPersonId",
                        column: x => x.InsuredPersonId,
                        principalTable: "FACES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CONTRACTS_FACES_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "FACES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CONTRACTS_FACES_PolicyHolderId",
                        column: x => x.PolicyHolderId,
                        principalTable: "FACES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CONTRACTS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONTRACT_RISKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Premium = table.Column<decimal>(type: "numeric", nullable: true),
                    InsuranceSum = table.Column<decimal>(type: "numeric", nullable: true),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    RiskId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTRACT_RISKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTRACT_RISKS_CONTRACTS_ContractId",
                        column: x => x.ContractId,
                        principalTable: "CONTRACTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONTRACT_RISKS_RISKS_RiskId",
                        column: x => x.RiskId,
                        principalTable: "RISKS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENT_AGREEMENTS_AgentId",
                table: "AGENT_AGREEMENTS",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENT_AGREEMENTS_LOBId",
                table: "AGENT_AGREEMENTS",
                column: "LOBId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENTS_FaceId",
                table: "AGENTS",
                column: "FaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AGENTS_IKPId",
                table: "AGENTS",
                column: "IKPId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENTS_StatusId",
                table: "AGENTS",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACT_RISKS_ContractId",
                table: "CONTRACT_RISKS",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACT_RISKS_RiskId",
                table: "CONTRACT_RISKS",
                column: "RiskId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACTS_AgentId",
                table: "CONTRACTS",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACTS_InsuredPersonId",
                table: "CONTRACTS",
                column: "InsuredPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACTS_OwnerId",
                table: "CONTRACTS",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACTS_PolicyHolderId",
                table: "CONTRACTS",
                column: "PolicyHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRACTS_ProductId",
                table: "CONTRACTS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_METAFIELDS_ProductId",
                table: "PRODUCT_METAFIELDS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_LOBId",
                table: "PRODUCTS",
                column: "LOBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENT_AGREEMENTS");

            migrationBuilder.DropTable(
                name: "CONTRACT_RISKS");

            migrationBuilder.DropTable(
                name: "PRODUCT_METAFIELDS");

            migrationBuilder.DropTable(
                name: "CONTRACTS");

            migrationBuilder.DropTable(
                name: "RISKS");

            migrationBuilder.DropTable(
                name: "AGENTS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "FACES");

            migrationBuilder.DropTable(
                name: "IKPS");

            migrationBuilder.DropTable(
                name: "STATUSES_AGENT_CONTRACT");

            migrationBuilder.DropTable(
                name: "LOBS");
        }
    }
}

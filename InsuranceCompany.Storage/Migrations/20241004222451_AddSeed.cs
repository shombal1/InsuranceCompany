using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FACES",
                columns: new[] { "ID", "DateBirth", "FirstName", "INN", "Lastname", "Name", "SecondName", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Александр", 1234567890, "Иванов", "Александр Сергеевич Иванов", "Сергеевич", "Юридическое лицо" },
                    { 2, new DateTime(1985, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Мария", 1876543210, "Петрова", "Мария Викторовна Петрова", "Викторовна", "Физическое лицо" }
                });

            migrationBuilder.InsertData(
                table: "LOBS",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "КАСКО" },
                    { 2, "ОСАГО" },
                    { 3, "Страхование путешественников" },
                    { 4, "Страхование от несчастных случаев" }
                });

            migrationBuilder.InsertData(
                table: "STATUSES_AGENT_CONTRACT",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Проект" },
                    { 2, "Действует" },
                    { 3, "Завершен" },
                    { 4, "Расторгнут" }
                });

            migrationBuilder.InsertData(
                table: "PRODUCTS",
                columns: new[] { "ID", "Active", "Description", "Formula", "LOBId", "Name" },
                values: new object[] { 1, true, "Гибкая система выбора нужных вам рисков и на требуемый срок", "(P1+P2*M2S+P3*M3S)*M1I", 3, "отпуск вашй мечты" });

            migrationBuilder.InsertData(
                table: "PRODUCT_METAFIELDS",
                columns: new[] { "ID", "JsonData", "ProductId", "Type" },
                values: new object[,]
                {
                    { 1, "{\"Type\":1,\"Index\":1,\"Key\":\"M1I\",\"Description\":\"\\u043A\\u043E\\u043B\\u0438\\u0447\\u0435\\u0441\\u0442\\u0432\\u043E \\u0434\\u043D\\u0435\\u0439 \\u0432 \\u043F\\u0443\\u0442\\u0435\\u0448\\u0435\\u0441\\u0442\\u0432\\u0438\\u0435\"}", 1, 1 },
                    { 2, "{\"Type\":1,\"Values\":[{\"Name\":\"\\u0432\\u044B\\u0441\\u043E\\u043A\\u0438\\u0439\",\"Value\":1.2},{\"Name\":\"\\u043D\\u0438\\u0437\\u043A\\u0438\\u0439\",\"Value\":0.9}],\"Index\":2,\"Key\":\"M2S\",\"Description\":\"\\u041F\\u0435\\u0440\\u0438\\u043E\\u0434 \\u043E\\u0442\\u0434\\u044B\\u0445\\u0430\"}", 1, 0 },
                    { 3, "{\"Type\":1,\"Values\":[{\"Name\":\"\\u0415\\u0432\\u0440\\u043E\\u043F\\u0430\",\"Value\":1},{\"Name\":\"\\u0422\\u0443\\u0440\\u0446\\u0438\\u0439\",\"Value\":1.2},{\"Name\":\"\\u041E\\u0410\\u042D\",\"Value\":1.1}],\"Index\":3,\"Key\":\"M3S\",\"Description\":\"\\u041D\\u0430\\u043F\\u0440\\u0432\\u043B\\u0435\\u043D\\u0438\\u0435 \\u043F\\u043E\\u043B\\u0435\\u0442\\u0430\"}", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_RISKS",
                columns: new[] { "ID", "Active", "InsuranceSum", "Key", "Name", "Premium", "ProductId" },
                values: new object[,]
                {
                    { 1, true, 500000m, "P1", "Несчастный случай", 5000m, 1 },
                    { 2, false, 10000m, "P2", "Утрата багажа", 1000m, 1 },
                    { 3, false, 20000m, "P3", "Задержка рейса", 2000m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FACES",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FACES",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LOBS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LOBS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LOBS",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRODUCT_METAFIELDS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PRODUCT_METAFIELDS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PRODUCT_METAFIELDS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PRODUCT_RISKS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PRODUCT_RISKS",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PRODUCT_RISKS",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "STATUSES_AGENT_CONTRACT",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "STATUSES_AGENT_CONTRACT",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "STATUSES_AGENT_CONTRACT",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "STATUSES_AGENT_CONTRACT",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PRODUCTS",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LOBS",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}

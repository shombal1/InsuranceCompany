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
                    { 1, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Александр", 1234567890, "Иванов", "Александр Сергеевич Иванов", "Сергеевич", 1 },
                    { 2, new DateTime(1985, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Мария", 1876543210, "Петрова", "Мария Викторовна Петрова", "Викторовна", 0 }
                });

            migrationBuilder.InsertData(
                table: "LOBS",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Авто" },
                    { 2, "Дом" },
                    { 3, "Путешествие" }
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
                values: new object[,] {
                    { 1, true, "Гибкая система выбора нужных вам рисков и на требуемый срок", "(P1+P2*M2S+P3*M3S)*M1I", 3, "Отпуск вашей мечты" },
                    { 2, true, "Страхование автогражданской ответственности. Страховой полис ОСАГО покрывает ущерб, нанесенный третьим лицам до 500000 руб.", "P1*M1S*M2I*M3S", 1, "ОСАГО" }
                }
            );

            migrationBuilder.InsertData(
                table: "PRODUCT_METAFIELDS",
                columns: new[] { "ID", "Type", "JsonData", "ProductId"},
                values: new object[,]
                {
                    {1, 1, "{\"Type\":1,\"Index\":1,\"Key\":\"M1I\",\"Description\":\"Количество дней в путешествии\"}", 1}, 
                    {2, 0, "{\"Type\":0,\"Values\":[{\"Name\":\"высокий\",\"Value\":1.2},{\"Name\":\"низкий\",\"Value\":0.9}],\"Index\":2,\"Key\":\"M2S\",\"Description\":\"Период отдыха\"}", 1}, 
                    {3, 0, "{\"Type\":0,\"Values\":[{\"Name\":\"Европа\",\"Value\":1},{\"Name\":\"Турция\",\"Value\":1.2},{\"Name\":\"ОАЭ\",\"Value\":1.1}],\"Index\":3,\"Key\":\"M3S\",\"Description\":\"Направление полета\"}", 1}, 
                    {4, 0, "{\"Type\":0,\"Values\":[{\"Name\":\"16-21 / 1\",\"Value\":1.92},{\"Name\":\"22-24 / 1\",\"Value\":1.72},{\"Name\":\"22-24 / 2\",\"Value\":1.71}],\"Index\":1,\"Key\":\"M1S\",\"Description\":\"Возраст и стаж\"}", 2}, 
                    {5, 1, "{\"Type\":1,\"Index\":2,\"Key\":\"M2I\",\"Description\":\"Коэффициент «бонус-малус»\"}", 2}, 
                    {6, 0, "{\"Type\":0,\"Values\":[{\"Name\":\"село\",\"Value\":0.76},{\"Name\":\"город\",\"Value\":1},{\"Name\":\"мегаполис\",\"Value\":1.8}],\"Index\":3,\"Key\":\"M3S\",\"Description\":\"Место использования\"}", 2}
                });

            migrationBuilder.InsertData(
                table: "PRODUCT_RISKS",
                columns: new[] { "ID", "Name", "Premium", "InsuranceSum", "ProductId", "Active", "Key" },
                values: new object[,]
                {
                    {1, "Несчастный случай", 5000m, 500000m, 1, true, "P1"}, 
                    {2, "Утрата багажа", 1000m, 10000m, 1, false, "P2"}, 
                    {3, "Задержка рейса", 2000m, 20000m, 1, false, "P3"}, 
                    {4, "Наступление страхового случая", 5000m, 0m, 2, true, "P1"}
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

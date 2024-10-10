using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SolveProblme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1960b215-7949-474f-8cc3-1c9bc8e67a61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b7f8bbe-d610-450d-b774-c842b77b79cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8a64575-0ad6-4f96-80dc-5b205c811650");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fc9f8a4-3744-4061-84f2-eb6306ee1d8c", null, "Admin", "ADMIN" },
                    { "e4534fb3-b022-4a1e-aec1-5eb557d887c3", null, "User", "USER" },
                    { "f3b6198e-95ac-40d2-926d-818aec70b925", null, "Editor", "Editor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fc9f8a4-3744-4061-84f2-eb6306ee1d8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4534fb3-b022-4a1e-aec1-5eb557d887c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b6198e-95ac-40d2-926d-818aec70b925");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1960b215-7949-474f-8cc3-1c9bc8e67a61", null, "User", "USER" },
                    { "6b7f8bbe-d610-450d-b774-c842b77b79cc", null, "Admin", "ADMIN" },
                    { "f8a64575-0ad6-4f96-80dc-5b205c811650", null, "Editor", "Editor" }
                });
        }
    }
}

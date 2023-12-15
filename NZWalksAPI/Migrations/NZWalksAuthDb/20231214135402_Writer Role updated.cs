using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class WriterRoleupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c309fa92-2123-47be-b397-a1c77adb502c",
                column: "NormalizedName",
                value: "WRITER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c309fa92-2123-47be-b397-a1c77adb502c",
                column: "NormalizedName",
                value: "WRİTER");
        }
    }
}

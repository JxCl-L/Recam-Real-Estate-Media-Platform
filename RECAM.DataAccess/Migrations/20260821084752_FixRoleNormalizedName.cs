using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RECAM.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixRoleNormalizedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-photographyCompany-static-id",
                column: "NormalizedName",
                value: "PHOTOGRAPHYCOMPANY");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-photographyCompany-static-id",
                column: "NormalizedName",
                value: "PHOTAGRAPHYCOMPANY");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shklift.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Balance",
                table: "ShkliftSettings",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "ShkliftSettings");
        }
    }
}

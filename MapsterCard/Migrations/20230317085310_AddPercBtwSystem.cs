using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapsterCard.Migrations
{
    /// <inheritdoc />
    public partial class AddPercBtwSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PercentageBetweenCardSystem",
                table: "Mapsters",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentageBetweenCardSystem",
                table: "Mapsters");
        }
    }
}

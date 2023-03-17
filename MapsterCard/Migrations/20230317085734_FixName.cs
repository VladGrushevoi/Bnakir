using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapsterCard.Migrations
{
    /// <inheritdoc />
    public partial class FixName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PercentageBetweenCardSystem",
                table: "Mapsters",
                newName: "PercentageOfOperationBetweenCardSystem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PercentageOfOperationBetweenCardSystem",
                table: "Mapsters",
                newName: "PercentageBetweenCardSystem");
        }
    }
}

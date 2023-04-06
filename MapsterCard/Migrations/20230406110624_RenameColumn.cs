using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapsterCard.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Expire",
                table: "Cards",
                newName: "ExpireTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpireTo",
                table: "Cards",
                newName: "Expire");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapsterCard.Migrations
{
    /// <inheritdoc />
    public partial class CardShortExpTo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortExpireTo",
                table: "Cards",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortExpireTo",
                table: "Cards");
        }
    }
}

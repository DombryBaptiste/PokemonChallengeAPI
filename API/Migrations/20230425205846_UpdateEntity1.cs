using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokémonChallenge.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PkmId",
                table: "Pokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PkmId",
                table: "Pokemon");
        }
    }
}

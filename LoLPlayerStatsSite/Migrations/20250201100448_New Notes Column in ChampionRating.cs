using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoLPlayerStatsSite.Migrations
{
    /// <inheritdoc />
    public partial class NewNotesColumninChampionRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ChampionRatings",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ChampionRatings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notes",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChampionRatings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Notes",
                value: null);

            migrationBuilder.UpdateData(
                table: "ChampionRatings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Notes",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ChampionRatings");
        }
    }
}

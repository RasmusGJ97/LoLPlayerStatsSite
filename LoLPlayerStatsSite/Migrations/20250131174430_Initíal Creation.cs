using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoLPlayerStatsSite.Migrations
{
    /// <inheritdoc />
    public partial class InitíalCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampionRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MyRating = table.Column<int>(type: "int", nullable: false),
                    Lane = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ToLearn = table.Column<bool>(type: "bit", nullable: false),
                    ChampionImg = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRatings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ChampionRatings",
                columns: new[] { "Id", "ChampionImg", "ChampionName", "Lane", "MyRating", "ToLearn" },
                values: new object[,]
                {
                    { 1, "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/1/18/AhriSquare.png/revision/latest?cb=20241024154252", "Ahri", "Mid", 10, false },
                    { 2, "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/5/58/NasusSquare.png/revision/latest?cb=20170802071450", "Nasus", "Top", 5, false },
                    { 3, "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/0/0f/JaxSquare.png/revision/latest?cb=20231012044232", "Jax", "Top", 3, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionRatings");
        }
    }
}

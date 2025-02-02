using LoLPlayerStatsSite.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace LoLPlayerStatsSite.Db.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<ChampionRating> ChampionRatings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ChampionRating>().HasData(
        //        new ChampionRating
        //        {
        //            Id = 1,
        //            ChampionName = "Ahri",
        //            MyRating = 10,
        //            Lane = LaneType.Mid,
        //            ToLearn = false,
        //            ChampionImg = "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/1/18/AhriSquare.png/revision/latest?cb=20241024154252"
        //        },
        //        new ChampionRating
        //        {
        //            Id = 2,
        //            ChampionName = "Nasus",
        //            MyRating = 5,
        //            Lane = LaneType.Top,
        //            ToLearn = false,
        //            ChampionImg = "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/5/58/NasusSquare.png/revision/latest?cb=20170802071450"
        //        },
        //        new ChampionRating
        //        {
        //            Id = 3,
        //            ChampionName = "Jax",
        //            MyRating = 3,
        //            Lane = LaneType.Top,
        //            ToLearn = true,
        //            ChampionImg = "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/0/0f/JaxSquare.png/revision/latest?cb=20231012044232"
        //        }
        //    );
        //}

    }
}

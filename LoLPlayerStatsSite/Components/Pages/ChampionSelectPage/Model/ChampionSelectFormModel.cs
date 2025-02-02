using LoLPlayerStatsSite.Db.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoLPlayerStatsSite.Components.Pages.ChampionSelectPage.Model
{
    public class ChampionSelectFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Champion name måste anges")]
        [MaxLength(50)]
        public string ChampionName { get; set; }

        [Required(ErrorMessage = "Rating måste vara mellan 0 - 10")]
        [Range(1, 10, ErrorMessage = "Rating måste vara mellan 0 - 10")]
        public int MyRating { get; set; }

        [Required(ErrorMessage = "Lane måste anges")]
        [MaxLength(10)]
        public string Lane { get; set; }

        [Required]
        public bool ToLearn { get; set; }

        [Required(ErrorMessage ="Champion image måste anges")]
        [MaxLength(255)]
        public string ChampionImg { get; set; }
        [MaxLength(255)]
        public string? Notes { get; set; }

        public static ChampionSelectFormModel Create(ChampionRating championRating)
        {
            return new ChampionSelectFormModel
            {
                Id = championRating.Id,
                ChampionName = championRating.ChampionName,
                MyRating = championRating.MyRating,
                Lane = championRating.Lane,
                ToLearn = championRating.ToLearn,
                ChampionImg = championRating.ChampionImg,
                Notes = championRating.Notes
            };
        }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoLPlayerStatsSite.Db.Models
{
    public class ChampionRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string ChampionName { get; set; }

        [Required]
        [Range(0, 10)]
        public int MyRating { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Lane { get; set; }

        [Required]
        public bool ToLearn { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string ChampionImg { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? Notes { get; set; }
    }
}

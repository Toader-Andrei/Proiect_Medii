using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii.Models
{
    public class Match
    {
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string HomeTeam { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string AwayTeam { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int HomeScore { get; set; }

        [Range(0, int.MaxValue)]
        public int AwayScore { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Medii.Models
{
    public class Training
    {
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(30, 180)] // Durata între 30 și 180 minute
        public int Duration { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Notes { get; set; }
    }
}

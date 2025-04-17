using System.ComponentModel.DataAnnotations;

namespace Oblig1_261658.Models
{
    public class Bruker
    {
        public int ID { get; set; }

        [Required]
        public string? Navn { get; set; }

        [Display(Name = "Kontakt Info")]
        public string? KontaktInfo { get; set; }

        [Display(Name = "Antall Spill")]
        public int AntallSpill { get; set; }
    }
}
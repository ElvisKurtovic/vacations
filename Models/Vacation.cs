using System.ComponentModel.DataAnnotations;

namespace vacations.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public decimal? Price { get; set; }

    }
}
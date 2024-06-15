namespace TrybeHotel.Models
{
    using System.ComponentModel.DataAnnotations;

    // 1. Adicione o atributo State na model City
    public class City {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string State { get; set; } = null!;
        public ICollection<Hotel>? Hotels { get; set; }
    }
}
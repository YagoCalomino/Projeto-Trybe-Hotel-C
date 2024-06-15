namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;

public class Hotel {
    [Key]
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public ICollection<Room>? Rooms { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; } = null!;
}
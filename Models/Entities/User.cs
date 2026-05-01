namespace reservations_api.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? DeviceToken { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

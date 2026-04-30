using System.ComponentModel.DataAnnotations;

namespace reservations_api.DTOs.Requests;

public class SaveDeviceTokenRequest
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public string DeviceToken { get; set; } = string.Empty;
}

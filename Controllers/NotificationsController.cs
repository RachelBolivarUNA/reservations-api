using Microsoft.AspNetCore.Mvc;
using reservations_api.DTOs.Requests;
using reservations_api.Services;

namespace reservations_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("token")]
    public async Task<IActionResult> SaveToken([FromBody] SaveDeviceTokenRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var saved = await _notificationService.SaveDeviceTokenAsync(request.UserId, request.DeviceToken);
        if (!saved)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new { message = "Token saved" });
    }
}

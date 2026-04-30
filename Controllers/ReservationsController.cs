using Microsoft.AspNetCore.Mvc;
using reservations_api.DTOs.Requests;
using reservations_api.Services;

namespace reservations_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByDate([FromQuery] DateOnly date)
    {
        var reservations = await _reservationService.GetByDateAsync(date);
        return Ok(reservations);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            var createdReservation = await _reservationService.CreateAsync(request);
            return Ok(createdReservation);
        }
        catch (InvalidOperationException ex)
        {
            if (ex.Message.Contains("Time conflict"))
            {
                return Conflict(new { message = ex.Message });
            }

            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        var deleted = await _reservationService.DeleteByIdAsync(id);
        if (!deleted)
        {
            return NotFound(new { message = "Reservation not found" });
        }

        return NoContent();
    }
}

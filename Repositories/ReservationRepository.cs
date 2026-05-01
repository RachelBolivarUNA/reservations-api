using Microsoft.EntityFrameworkCore;
using reservations_api.Data;
using reservations_api.Models.Entities;

namespace reservations_api.Repositories;

public class ReservationRepository : IReservationRepository
{
  private readonly AppDbContext _context;

  public ReservationRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Reservation> AddAsync(Reservation reservation)
  {
    await _context.Reservations.AddAsync(reservation);
    await _context.SaveChangesAsync();
    return reservation;
  }

  public async Task<Reservation?> GetByIdAsync(Guid id)
  {
    return await _context.Reservations
        .AsNoTracking()
        .FirstOrDefaultAsync(r => r.Id == id);
  }

  public async Task<List<Reservation>> GetByClassroomAndDateAsync(Guid classroomId, DateOnly date)
  {
    return await _context.Reservations
        .AsNoTracking()
        .Where(r => r.ClassroomId == classroomId && r.Date == date)
        .ToListAsync();
  }

  public async Task<List<Reservation>> GetByDateAsync(DateOnly date)
  {
    return await _context.Reservations
        .AsNoTracking()
        .Where(r => r.Date == date)
        .OrderBy(r => r.StartTime)
        .ToListAsync();
  }

  public async Task<bool> DeleteByIdAsync(Guid id)
  {
    var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
    if (reservation is null)
    {
      return false;
    }

    _context.Reservations.Remove(reservation);
    await _context.SaveChangesAsync();
    return true;
  }
}

using reservations_api.Models.Entities;

namespace reservations_api.Repositories;

public interface IReservationRepository
{
    Task<Reservation> AddAsync(Reservation reservation);
    Task<Reservation?> GetByIdAsync(Guid id);
    Task<List<Reservation>> GetByClassroomAndDateAsync(Guid classroomId, DateOnly date);
    Task<List<Reservation>> GetByDateAsync(DateOnly date);
    Task<bool> DeleteByIdAsync(Guid id);
}

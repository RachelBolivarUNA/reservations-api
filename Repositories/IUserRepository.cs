using reservations_api.Models.Entities;

namespace reservations_api.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAndPasswordAsync(string email, string password);
    Task<User?> GetByIdAsync(Guid id);
    Task<bool> SaveDeviceTokenAsync(Guid userId, string deviceToken);
}

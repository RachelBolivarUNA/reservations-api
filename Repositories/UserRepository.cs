using Microsoft.EntityFrameworkCore;
using reservations_api.Data;
using reservations_api.Models.Entities;

namespace reservations_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<bool> SaveDeviceTokenAsync(Guid userId, string deviceToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(currentUser => currentUser.Id == userId);
        if (user is null)
        {
            return false;
        }

        user.DeviceToken = deviceToken;
        await _context.SaveChangesAsync();
        return true;
    }
}

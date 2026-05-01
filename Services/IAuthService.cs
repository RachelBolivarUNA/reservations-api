using reservations_api.DTOs.Requests;
using reservations_api.DTOs.Responses;

namespace reservations_api.Services;

public interface IAuthService
{
    Task<UserResponse?> LoginAsync(LoginRequest request);
}

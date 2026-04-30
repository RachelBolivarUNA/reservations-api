using reservations_api.DTOs.Requests;
using reservations_api.DTOs.Responses;
using reservations_api.Mappers;
using reservations_api.Repositories;

namespace reservations_api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, request.Password);
        return user is null ? null : UserMapper.ToResponse(user);
    }
}

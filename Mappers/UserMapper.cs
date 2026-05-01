using reservations_api.DTOs.Responses;
using reservations_api.Models.Entities;

namespace reservations_api.Mappers;

public static class UserMapper
{
    public static UserResponse ToResponse(User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }
}

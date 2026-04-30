namespace reservations_api.Services;

public interface INotificationService
{
    Task<bool> SaveDeviceTokenAsync(Guid userId, string deviceToken);
    Task SendReservationConfirmedAsync(Guid userId);
}

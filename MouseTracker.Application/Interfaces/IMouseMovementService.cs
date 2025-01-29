using MouseTracker.Domain.Models;

namespace MouseTracker.Application.Interfaces
{
    public interface IMouseMovementService
    {
        Task SaveMouseDataAsync(List<MouseData> data);
    }
}

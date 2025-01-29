using MouseTracker.Domain.Models;

namespace MouseTracker.Domain.Interfaces
{
    public interface IMouseMovementRepository
    {
        Task AddAsync(MouseMovement movement);
    }
}

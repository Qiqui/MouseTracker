using MouseTracker.Application.Interfaces;
using MouseTracker.Domain.Interfaces;
using MouseTracker.Domain.Models;

namespace MouseTracker.Application.Services
{
    public class MouseMovementService : IMouseMovementService
    {
        private readonly IMouseMovementRepository _repository;

        public MouseMovementService(IMouseMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveMouseDataAsync(List<MouseData> data)
        {
            var movement = new MouseMovement
            {
                Data = System.Text.Json.JsonSerializer.Serialize(data)
            };

            await _repository.AddAsync(movement);
        }
    }
}

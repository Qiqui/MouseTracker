using Microsoft.EntityFrameworkCore;
using MouseTracker.Domain.Interfaces;
using MouseTracker.Domain.Models;

namespace MouseTracker.Infrastructure.Repositories
{
    public class MouseMovementRepository : IMouseMovementRepository
    {
        private readonly DatabaseContext _context;

        public MouseMovementRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MouseMovement movement)
        {
            _context.MouseMovements.Add(movement);
            await _context.SaveChangesAsync();
        }
    }
}

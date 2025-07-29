using Microsoft.EntityFrameworkCore;
using Wallet.Application.Interfaces;
using Wallet.Domain.Entities;
using Wallet.Infrastructure.Persistence;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Infrastructure.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly WalletDbContext _context;

        public MovementRepository(WalletDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Entities.Movement movement)
        {
            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entities.Movement>> GetByWalletIdAsync(int walletId)
        {
            return await _context.Movements
                .Where(m => m.WalletId == walletId)
                .ToListAsync();
        }
    }
}

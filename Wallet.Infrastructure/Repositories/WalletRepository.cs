using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Application.Interfaces;
using Entities = Wallet.Domain.Entities;
using Wallet.Infrastructure.Persistence;

namespace Wallet.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletDbContext _context;

        public WalletRepository(WalletDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Entities.Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Entities.Wallet wallet)
        {
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entities.Wallet>> GetAllAsync()
        {
            return await _context.Wallets.ToListAsync();
        }

        public async Task<Entities.Wallet?> GetByIdAsync(int id)
        {
            return await _context.Wallets
                .Include(w => w.Movements)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task UpdateAsync(Entities.Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}

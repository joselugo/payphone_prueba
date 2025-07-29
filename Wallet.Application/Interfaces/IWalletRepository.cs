using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Interfaces
{
    public interface IWalletRepository
    {
        Task<List<Entities.Wallet>> GetAllAsync();
        Task<Entities.Wallet?> GetByIdAsync(int id);
        Task AddAsync(Entities.Wallet wallet);
        Task UpdateAsync(Entities.Wallet wallet);
        Task DeleteAsync(Entities.Wallet wallet);
    }
}

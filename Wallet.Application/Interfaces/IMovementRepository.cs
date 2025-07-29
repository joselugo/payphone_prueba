using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Interfaces
{
    public interface IMovementRepository
    {
        Task<List<Entities.Movement>> GetByWalletIdAsync(int walletId);
        Task AddAsync(Entities.Movement movement);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Entities
{
    public class Movement
    {

        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public MovementType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Wallet Wallet { get; set; } = null!;
    }

    public enum MovementType
    {
        Credit,
        Debit
    }
}

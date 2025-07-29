using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string DocumentId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public List<Movement> Movements { get; set; } = new();
    }
}

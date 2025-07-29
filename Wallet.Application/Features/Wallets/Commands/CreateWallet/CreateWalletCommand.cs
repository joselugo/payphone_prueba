using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Features.Wallets.Commands.CreateWallet
{
    public class CreateWalletCommand : IRequest<int>
    {
        public string DocumentId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal InitialBalance { get; set; }
    }
}

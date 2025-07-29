using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallets.Queries.GetMovementsByWalletId
{
    public class GetMovementsByWalletIdQuery : IRequest<List<Entities.Movement>>
    {
        public int WalletId { get; set; }

        public GetMovementsByWalletIdQuery(int walletId)
        {
            WalletId = walletId;
        }
    }
}

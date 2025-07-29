using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallets.Queries.GetAllWallets
{
    public class GetAllWalletsQueryHandler : IRequestHandler<GetAllWalletsQuery, List<Entities.Wallet>>
    {
        private readonly IWalletRepository _walletRepository;

        public GetAllWalletsQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<List<Entities.Wallet>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken)
        {
            return await _walletRepository.GetAllAsync();
        }
    }
}

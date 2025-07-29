using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Entities = Wallet.Domain.Entities;


namespace Wallet.Application.Features.Wallets.Queries.GetWalletById
{
    public class GetWalletByIdQueryHandler : IRequestHandler<GetWalletByIdQuery, Entities.Wallet?>
    {
        private readonly IWalletRepository _walletRepository;

        public GetWalletByIdQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Entities.Wallet?> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            return await _walletRepository.GetByIdAsync(request.Id);
        }
    }
}

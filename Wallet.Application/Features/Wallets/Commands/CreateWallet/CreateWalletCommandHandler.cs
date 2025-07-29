using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallets.Commands.CreateWallet
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, int>
    {
        private readonly IWalletRepository _walletRepository;

        public CreateWalletCommandHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<int> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = new Entities.Wallet
            {
                DocumentId = request.DocumentId,
                Name = request.Name,
                Balance = request.InitialBalance,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _walletRepository.AddAsync(wallet);
            return wallet.Id;
        }
    }
}

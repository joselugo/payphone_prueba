using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallets.Commands.TransferBalance
{
    public class TransferBalanceCommandHandler : IRequestHandler<TransferBalanceCommand, bool>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMovementRepository _movementRepository;

        public TransferBalanceCommandHandler(IWalletRepository walletRepository, IMovementRepository movementRepository)
        {
            _walletRepository = walletRepository;
            _movementRepository = movementRepository;
        }

        public async Task<bool> Handle(TransferBalanceCommand request, CancellationToken cancellationToken)
        {
            if (request.Amount <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero.");

            var fromWallet = await _walletRepository.GetByIdAsync(request.FromWalletId);
            var toWallet = await _walletRepository.GetByIdAsync(request.ToWalletId);

            if (fromWallet == null)
                throw new InvalidOperationException("La billetera de origen no existe.");
            if (toWallet == null)
                throw new InvalidOperationException("La billetera de destino no existe.");
            if (fromWallet.Balance < request.Amount)
                throw new InvalidOperationException("Saldo insuficiente en la billetera de origen.");

            // Actualizar saldos
            fromWallet.Balance -= request.Amount;
            toWallet.Balance += request.Amount;

            fromWallet.UpdatedAt = toWallet.UpdatedAt = DateTime.UtcNow;

            await _walletRepository.UpdateAsync(fromWallet);
            await _walletRepository.UpdateAsync(toWallet);

            // Registrar movimientos
            var debit = new Entities.Movement
            {
                WalletId = fromWallet.Id,
                Amount = request.Amount,
                Type = Entities.MovementType.Debit
            };

            var credit = new Entities.Movement
            {
                WalletId = toWallet.Id,
                Amount = request.Amount,
                Type = Entities.MovementType.Credit
            };

            await _movementRepository.AddAsync(debit);
            await _movementRepository.AddAsync(credit);

            return true;
        }
    }
}

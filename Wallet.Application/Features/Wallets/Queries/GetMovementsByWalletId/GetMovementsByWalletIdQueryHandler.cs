using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallets.Queries.GetMovementsByWalletId
{
    internal class GetMovementsByWalletIdQueryHandler : IRequestHandler<GetMovementsByWalletIdQuery, List<Entities.Movement>>
    {
        private readonly IMovementRepository _movementRepository;

        public GetMovementsByWalletIdQueryHandler(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task<List<Entities.Movement>> Handle(GetMovementsByWalletIdQuery request, CancellationToken cancellationToken)
        {
            return await _movementRepository.GetByWalletIdAsync(request.WalletId);
        }
    }
}

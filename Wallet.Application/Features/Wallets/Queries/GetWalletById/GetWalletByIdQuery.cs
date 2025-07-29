using MediatR;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallets.Queries.GetWalletById;

public class GetWalletByIdQuery : IRequest<Entities.Wallet?>
{
    public int Id { get; set; }

    public GetWalletByIdQuery(int id)
    {
        Id = id;
    }
}

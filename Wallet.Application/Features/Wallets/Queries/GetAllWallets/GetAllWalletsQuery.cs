using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Wallet.Domain.Entities;

namespace Wallet.Application.Features.Wallets.Queries.GetAllWallets
{
    public class GetAllWalletsQuery : IRequest<List<Entities.Wallet>> 
    {

    }
}

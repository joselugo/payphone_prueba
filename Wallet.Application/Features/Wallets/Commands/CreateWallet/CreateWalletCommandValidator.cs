using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Features.Wallets.Commands.CreateWallet
{
    public class CreateWalletCommandValidator : AbstractValidator<CreateWalletCommand>
    {
        public CreateWalletCommandValidator()
        {
            RuleFor(x => x.DocumentId)
                .NotEmpty().WithMessage("El documento es obligatorio.")
                .MaximumLength(50);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.InitialBalance)
                .GreaterThanOrEqualTo(0).WithMessage("El saldo inicial no puede ser negativo.");
        }
    }
}

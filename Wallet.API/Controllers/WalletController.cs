using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Features.Wallets.Commands.CreateWallet;
using Wallet.Application.Features.Wallets.Commands.TransferBalance;
using Wallet.Application.Features.Wallets.Queries.GetAllWallets;
using Wallet.Application.Features.Wallets.Queries.GetMovementsByWalletId;
using Wallet.Application.Features.Wallets.Queries.GetWalletById;

namespace Wallet.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class WalletController : ControllerBase
{
    private readonly IMediator _mediator;

    public WalletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWallet([FromBody] CreateWalletCommand command)
    {
        var walletId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetWalletById), new { id = walletId }, new { walletId });
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWalletById(int id)
    {
        var result = await _mediator.Send(new GetWalletByIdQuery(id));

        if (result == null)
            return NotFound($"No se encontró una billetera con ID {id}");

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllWallets()
    {
        var result = await _mediator.Send(new GetAllWalletsQuery());
        return Ok(result);
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferBalanceCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return result ? Ok("Transferencia realizada correctamente.") : BadRequest("No se pudo realizar la transferencia.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/movements")]
    public async Task<IActionResult> GetMovements(int id)
    {
        var result = await _mediator.Send(new GetMovementsByWalletIdQuery(id));
        return Ok(result);
    }

}

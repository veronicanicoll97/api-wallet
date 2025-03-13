using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Services;
using Wallet.Domain.Entities;

namespace Wallet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletController : ControllerBase
{
    private readonly WalletService _walletService;

    public WalletController(WalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWallets()
    {
        var wallets = await _walletService.GetAllWalletsAsync();
        return Ok(wallets);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAllWalletById(int id)
    {
        var wallet = await _walletService.GetWalletByIdAsync(id);
        if (wallet == null)
        {
            return NotFound(new { message = "Wallet not found" });
        }
        return Ok(wallet);
    }

    [HttpPost]
    public async Task<IActionResult> AddWallet([FromBody] Domain.Entities.Wallet wallet)
    {
        try
        {
            await _walletService.AddWalletAsync(wallet);
            return CreatedAtAction(nameof(GetAllWallets), new { id = wallet.Id }, wallet);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

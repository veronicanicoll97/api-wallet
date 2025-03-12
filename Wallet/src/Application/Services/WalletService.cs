using Wallet.Domain.Entities;
using Wallet.Domain.Repositories;

namespace Wallet.Application.Services;

public class WalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Wallet>> GetAllWalletsAsync()
    {
        return await _walletRepository.GetAllAsync();
    }

    public async Task<Domain.Entities.Wallet> GetWalletByIdAsync(int id)
    {
        return await _walletRepository.GetByIdAsync(id);
    }

    public async Task AddWalletAsync(Domain.Entities.Wallet wallet)
    {
        // Reglas de negocio antes de guardar el usuario
        if (string.IsNullOrEmpty(wallet.Name) || string.IsNullOrEmpty(wallet.DocumentId))
        {
            throw new ArgumentException("El nombre y numero de documento son obligatorios.");
        }

        // Verificar si el usuario ya existe
        var existingWallets = await _walletRepository.GetAllAsync();
        if (existingWallets.Any(u => u.DocumentId == wallet.DocumentId))
        {
            throw new InvalidOperationException("Billetera registrada");
        }

        if (wallet.Balance < 0)
        {
            throw new InvalidOperationException("El monto debe ser 0 o mayor a 0.");
        }

        await _walletRepository.AddAsync(wallet);
    }
}

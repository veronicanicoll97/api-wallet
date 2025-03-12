namespace Wallet.Domain.Repositories;

public interface IWalletRepository
{
    Task AddAsync(Entities.Wallet wallet);
    // Task<Entities.Wallet> UpdateAsync(Entities.Wallet wallet);
    // Task<Entities.Wallet> DeleteAsync(int id);
    Task<Entities.Wallet> GetByIdAsync(int id);
    Task<IEnumerable<Entities.Wallet>> GetAllAsync();
}

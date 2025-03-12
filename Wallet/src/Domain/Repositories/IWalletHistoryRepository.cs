namespace Wallet.Domain.Repositories;

public interface IWalletHistoryRepository
{
    Task<Entities.WalletHistory> Create(Entities.WalletHistory wallet);
    Task<Entities.WalletHistory> Get(int id);
    Task<IEnumerable<Entities.WalletHistory>> GetAll();
}
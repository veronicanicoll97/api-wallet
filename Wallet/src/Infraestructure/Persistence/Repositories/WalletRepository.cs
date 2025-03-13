using Dapper;
using System.Data;
using Wallet.Domain.Entities;
using Wallet.Domain.Repositories;
using Wallet.Infraestructure.Persistence.Config;
namespace Wallet.Infraestructure.Persistence.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly DatabaseConnection _databaseConnection;

    public WalletRepository(DatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public async Task<IEnumerable<Domain.Entities.Wallet>> GetAllAsync()
    {
        using var connection = _databaseConnection.CreateConnection();
        return await connection.QueryAsync<Domain.Entities.Wallet>("SELECT id, \"name\", \"documentId\", balance, \"createdAt\", \"updatedAt\" FROM wallets");
    }

    public async Task<Domain.Entities.Wallet> GetByIdAsync(int id)
    {
        using var connection = _databaseConnection.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Domain.Entities.Wallet>(
            "SELECT id, \"name\", \"documentId\", balance, \"createdAt\", \"updatedAt\" FROM wallets WHERE id = @id", new {  id });
    }

    public async Task AddAsync(Domain.Entities.Wallet wallet)
    {
        using var connection = _databaseConnection.CreateConnection();
        var query = "INSERT INTO wallets (\"documentId\", name, balance) VALUES (@DocumentId, @Name, @Balance)";
        await connection.ExecuteAsync(query, wallet);
    }
}
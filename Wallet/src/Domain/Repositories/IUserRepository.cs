using Wallet.Domain.Entities;

namespace Wallet.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetUser(string username, string password);
}



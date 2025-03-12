namespace Wallet.Domain.Entities;

public class WalletHistory
{
    public int Id { get; set; }
    public int WalletId { get; set; }
    public long Amount { get; set; }
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
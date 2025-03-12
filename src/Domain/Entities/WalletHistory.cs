namespace src.Domain.Entities;

public class WalletHistory {
    public int Id { get; set; }
    public int walletId { get; set; }
    public long amount { get; set; }
    public string type { get; set; }

    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}
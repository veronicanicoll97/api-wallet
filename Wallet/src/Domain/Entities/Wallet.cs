namespace Wallet.Domain.Entities;

public class Wallet
{
    public int Id { get; set; }
    public string DocumentId { get; set; }
    public string Name { get; set; }
    public long Balance { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
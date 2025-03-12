namespace src.Domain.Entities;

public class Wallet {
    public int Id { get; set; }
    public string documentId { get; set; }
    public string name { get; set; }
    public long balance { get; set; }

    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}
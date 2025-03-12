namespace Wallet.Domain.ValueObject;

public record Money {
    public decimal Amount { get; }

    public Money(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("El monto debe ser mayor que cero.", nameof(amount));

        Amount = amount;
    }

    public static Money operator +(Money a, Money b) => new(a.Amount + b.Amount);
    public static Money operator -(Money a, Money b)
    {
        if (a.Amount < b.Amount)
            throw new InvalidOperationException("No puedes restar más de lo disponible.");
        
        return new(a.Amount - b.Amount);
    }

    public override string ToString() => $"{Amount:C}";

}
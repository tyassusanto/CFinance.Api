using CFinance.Domain.Enums;

namespace CFinance.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public UserRole Role { get; set; }
    public decimal Balance { get; set; }

    public void DeductBalance(decimal amount)
    {
        if (amount <= 0)
            throw new Exception("Invalid amount");

        if (Balance < amount)
            throw new Exception("Insufficient balance");

        Balance -= amount;
    }
    public void AddBalance(decimal amount)
    {
        if (amount <= 0)
            throw new Exception("Invalid amount");

        Balance += amount;
    }
}

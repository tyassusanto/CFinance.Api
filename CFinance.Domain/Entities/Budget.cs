using CFinance.Domain.Rules;
using CFinance.Domain.Common.Exceptions;

namespace CFinance.Domain.Entities;

public class Budget
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Budget() { }

    public Budget(Guid userId, decimal amount)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
    }

    public void SetAmount(decimal userBalance, decimal amount)
    {
        if (!BudgetRules.IsWithinLimit(userBalance, amount))
            throw new DomainException("Budget exceeds 40% of balance");

        Amount = amount;
    }
}

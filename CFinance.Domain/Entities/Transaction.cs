using CFinance.Domain.Common;
using CFinance.Domain.Enums;

namespace CFinance.Domain.Entities;

public class Transaction : BaseEntity
{
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public string Category { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public Guid CreatedBy { get; private set; }

    protected Transaction() { }

    public Transaction(
        decimal amount,
        TransactionType type,
        string category,
        string description,
        Guid createdBy)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Amount = amount;
        Type = type;
        Category = category;
        Description = description;
        CreatedBy = createdBy;
    }
}

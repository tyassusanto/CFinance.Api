using CFinance.Domain.Enums;

namespace CFinance.Domain.Entities;

public class Reimbursement
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; private set; } = null!;
    public decimal Amount { get; set; }
    public string Description { get; set; } = null!;
    public ReimbursementStatus Status { get; private set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Reimbursement(Guid userId, decimal amount, string description)
    {
        UserId = userId;
        Amount = amount;
        Description = description;
        Status = ReimbursementStatus.Pending;
    }

    public void Approve()
    {
        if (Status != ReimbursementStatus.Pending)
            throw new Exception("Only Pending reimbursement can be approved");

        Status = ReimbursementStatus.Approved;
    }

    public void Reject()
    {
        if (Status != ReimbursementStatus.Pending)
            throw new Exception("Only Pending reimbursement can be rejected");

        Status = ReimbursementStatus.Rejected;
    }
}

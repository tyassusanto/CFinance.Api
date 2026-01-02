namespace CFinance.Application.DTOs.Reimbursement;

public record ReimbursementResponse(
    Guid Id,
    string UserEmail,
    decimal Amount,
    string Description,
    string Status,
    DateTime CreatedAt
);

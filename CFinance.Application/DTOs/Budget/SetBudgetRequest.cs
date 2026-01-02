namespace CFinance.Application.DTOs.Budget;

public record SetBudgetRequest(
    Guid StaffUserId,
    decimal Amount
);

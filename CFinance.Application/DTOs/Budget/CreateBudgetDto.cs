namespace CFinance.Application.DTOs.Budget;

public record CreateBudgetDto(
    string Name,
    decimal LimitAmount
);
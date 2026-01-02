using CFinance.Application.DTOs.Budget;

namespace CFinance.Application.Interfaces.Services;

public interface IBudgetService
{
    Task SetBudgetAsync(Guid financeUserId, SetBudgetRequest request);
}

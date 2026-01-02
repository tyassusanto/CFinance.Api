using CFinance.Domain.Entities;

namespace CFinance.Application.Interfaces.Repositories;

public interface IBudgetRepository
{
    Task<Budget?> GetCurrentAsync(Guid userId);
    Task AddAsync(Budget budget);
    Task UpdateAsync(Budget budget);
    Task<Budget?> GetActiveByUserIdAsync(Guid userId);
}

using CFinance.Domain.Entities;

namespace CFinance.Application.Interfaces.Repositories;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task<decimal> GetCurrentBalanceAsync();
}

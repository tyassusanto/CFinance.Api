using CFinance.Application.DTOs.Transaction;

namespace CFinance.Application.Interfaces.Services;

public interface ITransactionService
{
    Task CreateAsync(CreateTransactionDto dto, Guid userId);
}

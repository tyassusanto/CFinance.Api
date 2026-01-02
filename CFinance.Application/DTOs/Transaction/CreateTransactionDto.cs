using CFinance.Domain.Enums;

namespace CFinance.Application.DTOs.Transaction;

public record CreateTransactionDto(
    decimal Amount,
    TransactionType Type,
    string Category,
    string Description
);


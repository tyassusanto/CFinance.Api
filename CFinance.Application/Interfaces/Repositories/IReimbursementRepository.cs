using CFinance.Domain.Entities;
using CFinance.Domain.Enums;

namespace CFinance.Application.Interfaces.Repositories;

public interface IReimbursementRepository
{
    Task AddAsync(Reimbursement reimbursement);
    Task<Reimbursement?> GetByIdAsync(Guid id);
    Task UpdateAsync(Reimbursement reimbursement);
    Task<List<Reimbursement>> GetAllAsync(ReimbursementStatus? status);
}

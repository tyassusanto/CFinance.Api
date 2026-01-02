using CFinance.Application.DTOs.Reimbursement;
using CFinance.Domain.Enums;

namespace CFinance.Application.Interfaces.Services;

public interface IReimbursementService
{
    Task SubmitAsync(Guid userId, SubmitReimbursementRequest request);
    Task ApproveAsync(Guid reimbursementId);
    Task RejectAsync(Guid reimbursementId);
    Task<List<ReimbursementResponse>> GetAllAsync(ReimbursementStatus? status);
}

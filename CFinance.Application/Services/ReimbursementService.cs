using CFinance.Application.DTOs.Reimbursement;
using CFinance.Application.Interfaces;
using CFinance.Application.Interfaces.Repositories;
using CFinance.Application.Interfaces.Services;
using CFinance.Application.Common.Exceptions;
using CFinance.Domain.Enums;
using CFinance.Domain.Entities;

namespace CFinance.Application.Services;

public class ReimbursementService : IReimbursementService
{
    private readonly IReimbursementRepository _reimbursementRepo;
    private readonly IUserRepository _userRepo;
    
    private readonly IBudgetRepository _budgetRepo;
    private readonly IUnitOfWork _uow;

    public ReimbursementService(
        IReimbursementRepository reimbursementRepo,
        IUserRepository userRepo,
        IUnitOfWork uow,
        IBudgetRepository budgetRepo)
    {
        _reimbursementRepo = reimbursementRepo;
        _userRepo = userRepo;
        _uow = uow;
        _budgetRepo = budgetRepo; 
    }

    public async Task<List<ReimbursementResponse>> GetAllAsync(ReimbursementStatus? status)
    {
        var list = await _reimbursementRepo.GetAllAsync(status);

        return list.Select(x => new ReimbursementResponse(
            x.Id,
            x.User.Email,
            x.Amount,
            x.Description,
            x.Status.ToString(),
            x.CreatedAt
        )).ToList();
    }

    public async Task SubmitAsync(Guid userId, SubmitReimbursementRequest request)
    {
        var budget = await _budgetRepo.GetActiveByUserIdAsync(userId)
            ?? throw new BusinessException("Budget not set");

        if (request.Amount > budget.Amount)
            throw new BusinessException("Reimbursement amount exceeds budget");

        var reimbursement = new Reimbursement(
            userId,
            request.Amount,
            request.Description
        );

        await _reimbursementRepo.AddAsync(reimbursement);
    }

    public async Task ApproveAsync(Guid reimbursementId)
    {
        await _uow.BeginTransactionAsync();

        try
        {
            var reimbursement = await _reimbursementRepo.GetByIdAsync(reimbursementId)
                ?? throw new NotFoundException("Reimbursement not found");

            if (reimbursement.Status != ReimbursementStatus.Pending)
                throw new BusinessException("Invalid reimbursement state");

            var user = await _userRepo.GetByIdAsync(reimbursement.UserId)
                ?? throw new NotFoundException("User not found");

            reimbursement.Approve();
            user.DeductBalance(reimbursement.Amount);

            await _reimbursementRepo.UpdateAsync(reimbursement);
            await _userRepo.UpdateAsync(user);

            await _uow.CommitAsync();
        }
        catch
        {
            await _uow.RollbackAsync();
            throw;
        }
    }

    public async Task RejectAsync(Guid reimbursementId)
    {
        var reimbursement = await _reimbursementRepo.GetByIdAsync(reimbursementId)
            ?? throw new NotFoundException("Reimbursement not found");

        if (reimbursement.Status != ReimbursementStatus.Pending)
            throw new BusinessException("Invalid reimbursement state");

        reimbursement.Reject();
        await _reimbursementRepo.UpdateAsync(reimbursement);
    }
}

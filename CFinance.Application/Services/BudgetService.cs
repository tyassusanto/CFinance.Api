using CFinance.Application.Common.Exceptions;
using CFinance.Application.DTOs.Budget;
using CFinance.Application.Interfaces.Repositories;
using CFinance.Application.Interfaces.Services;
using CFinance.Domain.Entities;
using CFinance.Domain.Enums;

namespace CFinance.Application.Services;

public class BudgetService : IBudgetService
{
    private readonly IUserRepository _userRepo;
    private readonly IBudgetRepository _budgetRepo;

    public BudgetService(IUserRepository userRepo, IBudgetRepository budgetRepo)
    {
        _userRepo = userRepo;
        _budgetRepo = budgetRepo;
    }

    public async Task SetBudgetAsync(Guid financeUserId, SetBudgetRequest request)
    {
        // pastikan finance
        var finance = await _userRepo.GetByIdAsync(financeUserId)
            ?? throw new NotFoundException("Finance not found");

        if (finance.Role != UserRole.Finance)
            throw new BusinessException("Only finance can set budget");

        // target staff
        var staff = await _userRepo.GetByIdAsync(request.StaffUserId)
            ?? throw new NotFoundException("Staff not found");

        if (staff.Role != UserRole.Staff)
            throw new BusinessException("Target user must be staff");

        // cari budget STAFF
        var budget = await _budgetRepo.GetActiveByUserIdAsync(staff.Id);

        if (budget == null)
        {
            budget = new Budget(staff.Id, request.Amount);
            await _budgetRepo.AddAsync(budget);
            return;
        }

        budget.SetAmount(staff.Balance, request.Amount);
        await _budgetRepo.UpdateAsync(budget);
    }

}

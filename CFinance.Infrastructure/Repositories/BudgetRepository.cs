using CFinance.Application.Interfaces.Repositories;
using CFinance.Domain.Entities;
using CFinance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CFinance.Infrastructure.Repositories;

public class BudgetRepository : IBudgetRepository
{
    private readonly AppDbContext _context;

    public BudgetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Budget budget)
    {
        _context.Budgets.Add(budget);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Budget budget)
    {
        _context.Budgets.Update(budget);
        await _context.SaveChangesAsync();
    }

    public async Task<Budget?> GetCurrentAsync(Guid userId)
    {
        return await _context.Budgets
            .Where(b => b.UserId == userId)
            .OrderByDescending(b => b.CreatedAt)
            .FirstOrDefaultAsync();
    }

    public async Task<Budget?> GetActiveByUserIdAsync(Guid userId)
    {
        return await _context.Budgets
            .Where(b => b.UserId == userId)
            .OrderByDescending(b => b.CreatedAt)
            .FirstOrDefaultAsync();
    }
}

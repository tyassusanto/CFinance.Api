using CFinance.Application.Interfaces.Repositories;
using CFinance.Domain.Entities;
using CFinance.Domain.Enums;
using CFinance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CFinance.Infrastructure.Repositories;

public class ReimbursementRepository : IReimbursementRepository
{
    private readonly AppDbContext _context;

    public ReimbursementRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Reimbursement>> GetAllAsync(ReimbursementStatus? status)
    {
        var query = _context.Reimbursements
            .Include(x => x.User)
            .AsQueryable();

        if (status.HasValue)
            query = query.Where(x => x.Status == status);

        return await query
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task AddAsync(Reimbursement reimbursement)
    {
        _context.Reimbursements.Add(reimbursement);
        await _context.SaveChangesAsync();
    }

    public async Task<Reimbursement?> GetByIdAsync(Guid id)
    {
        return await _context.Reimbursements
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Reimbursement reimbursement)
    {
        _context.Reimbursements.Update(reimbursement);
        await _context.SaveChangesAsync();
    }
}

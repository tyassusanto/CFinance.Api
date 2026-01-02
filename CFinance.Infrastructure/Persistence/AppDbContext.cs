using Microsoft.EntityFrameworkCore;
using CFinance.Domain.Entities;

namespace CFinance.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Budget> Budgets => Set<Budget>();
    public DbSet<Reimbursement> Reimbursements => Set<Reimbursement>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Budget>()
        .HasOne(b => b.User)
        .WithMany()
        .HasForeignKey(b => b.UserId);
}
}

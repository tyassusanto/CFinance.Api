using BCrypt.Net;
using CFinance.Domain.Entities;
using CFinance.Domain.Enums;
using CFinance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CFinance.Infrastructure.Seeders;

public static class UserSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Users.AnyAsync(x => x.Role == UserRole.Finance))
        {
            context.Users.Add(new User
            {
                Email = "finance@cfinance.local",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Role = UserRole.Finance,
                Balance = 10_000_000
            });
        }

        if (!await context.Users.AnyAsync(x => x.Role == UserRole.Staff))
        {
            context.Users.Add(new User
            {
                Email = "staff@cfinance.local",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Role = UserRole.Staff,
                Balance = 0
            });
        }

        await context.SaveChangesAsync();

    }
}

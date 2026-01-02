using BCrypt.Net;
using CFinance.Domain.Entities;
using CFinance.Domain.Enums;
using CFinance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CFinance.Infrastructure.Seeders;

public static class AdminSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Users.AnyAsync(x => x.Role == UserRole.Admin))
        {
            context.Users.Add(new User
            {
                Email = "admin@cfinance.local",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Role = UserRole.Admin,
                Balance = 0
            });

            await context.SaveChangesAsync();
        }
    }
}


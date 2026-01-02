using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CFinance.Infrastructure.Persistence;
using CFinance.Application.Interfaces.Repositories;
using CFinance.Infrastructure.Repositories;
using CFinance.Application.Interfaces;

namespace CFinance.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBudgetRepository, BudgetRepository>();
        services.AddScoped<IReimbursementRepository, ReimbursementRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

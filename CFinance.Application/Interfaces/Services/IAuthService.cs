using CFinance.Domain.Entities;

namespace CFinance.Application.Interfaces.Services;

public interface IAuthService
{
    Task<User> ValidateUserAsync(string email, string password);
}
